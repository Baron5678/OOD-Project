using OODProj.Data;
using OODProj.NewsReport;
using OODProj.Repository;
using OODProj.Utilities;
using OODProj.AbstractFactories;
using System.Text.Json;
using System.Text.RegularExpressions;
using OODProj.DictionaryBuilders;

namespace OODProj.Commands.Functionality
{
    public class CommandExecutor : IExecutor
    {
        Regex regex = new(@"([\w\.]+)(<=|>=|!=|=)(\d{1,2}:\d{2}(AM|PM)|-?\d+(?:\.\d+)?|\w+)");

        public void Visit(Print printCommand, DataContainer data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText($@"..\..\..\DataFiles\JSON\snapshot_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.json", json);
        }

        public void Visit(Report printCommand, INewsIterator newsGenerator)
        {
            //if (newsGenerator.IsAllGenerated)
            //    Console.WriteLine("All news generated");
            while (!newsGenerator.IsAllGenerated)
            {
                Console.WriteLine(newsGenerator.GenerateNextNews());
            }
            Console.WriteLine(newsGenerator.CountNews);
            Console.WriteLine("All news generated");
        }

        public bool WhereExpression(List<string> stringExpression, IPrimaryKeyed obj, string nameClass)
        {
            bool left = false, right;
            int i = 0;
            
                Match leftMatch = regex.Match(stringExpression[i]);
                if (!leftMatch.Success)
                    throw new ArgumentException("No match found.");
               
                left = DictionaryReflection.Comparer[leftMatch.Groups[2].Value](obj, nameClass, leftMatch.Groups[1].Value, leftMatch.Groups[3].Value);
                if (i + 2 >= stringExpression.Count)
                    return left;
                Match rightMatch = regex.Match(stringExpression[i + 2]);
                if (!rightMatch.Success)
                    throw new ArgumentException("No match found.");
                right = DictionaryReflection.Comparer[rightMatch.Groups[2].Value](obj, nameClass, rightMatch.Groups[1].Value, rightMatch.Groups[3].Value);
                left = DictionaryReflection.LogicOperator[stringExpression[i + 1]](left, right);
             i += 4;
            while(i < stringExpression.Count) 
            {
                rightMatch = regex.Match(stringExpression[i]);
                if (!rightMatch.Success)
                    throw new ArgumentException("No match found.");
                right = DictionaryReflection.Comparer[rightMatch.Groups[2].Value](obj, nameClass, rightMatch.Groups[1].Value, rightMatch.Groups[3].Value);
                left = DictionaryReflection.LogicOperator[stringExpression[i - 1]](left, right);
                i += 2;
            }

            return left;
        }


        public void Visit(Display displayCommand, Dictionary<string, IRepository> repos, List<string>? Parameters)
        {
            ArgumentNullException.ThrowIfNull(Parameters);
            List<string> fields = [.. Parameters[0].Split(',')];
            string nameClass = Parameters[2];
            if (fields[0] == "*") 
            {
                fields = DictionaryReflection.Getter[nameClass].Keys.ToList();
            }
            foreach (var item in repos[nameClass].GetPrimaryKeyedObjects())
            {
                foreach (var field in fields)
                {
                    Console.WriteLine($"{nameClass}");
                    if (Parameters.Count == 3 || WhereExpression(Parameters[4..], item, nameClass))
                        Console.WriteLine($"{field}: {DictionaryReflection.Getter[nameClass][field](item)}");
                }
                Console.WriteLine();
            }
        }

        public void Visit(Update update, Dictionary<string, IRepository> repos, List<string>? Parameters)
        
        {
            ArgumentNullException.ThrowIfNull(Parameters);
            string nameClass = Parameters[0];
            string[] fields = Parameters[2][1..^1].Split(',');
            foreach (var item in repos[nameClass].GetPrimaryKeyedObjects())
            {
                foreach (var field in fields)
                {
                    var match = regex.Match(field);
                    if (Parameters.Count == 4 || WhereExpression(Parameters[4..], item, nameClass))
                    {
                        DictionaryReflection.Setter[nameClass][match.Groups[1].Value](item, match.Groups[3].Value);
                        Console.WriteLine($"{field}: {DictionaryReflection.Getter[nameClass][match.Groups[1].Value](item)}");
                    }
                }
            }
        }

        public void Visit(Delete delete, Dictionary<string, IRepository> repos, List<string>? Parameters)
        {
            ArgumentNullException.ThrowIfNull(Parameters);
            string nameClass = Parameters[0];

            if (Parameters.Count == 1)
            {
                repos[nameClass].DeleteAll();
                return;
            }   

            foreach (var item in repos[nameClass].GetPrimaryKeyedObjects())
            {
                    Console.WriteLine($"{nameClass}");
                    if (WhereExpression(Parameters[2..], item, nameClass)) 
                    {
                         repos[nameClass].DeleteFromRepo(item);
                        Console.WriteLine("Deleted");
                        Console.WriteLine($"{item}");
                    }
                Console.WriteLine();
            }
        }

        public void Visit(Add add, Dictionary<string, IRepository> repos, Dictionary<string, IDictionaryBuilder> builders, List<string>? Parameters)
        {
            ArgumentNullException.ThrowIfNull(Parameters);
            string nameClass = Parameters[0];
            string[] fields = Parameters[2][1..^1].Split(',');
            var builder = builders[nameClass];
            foreach (var field in fields) 
            {
                var match = regex.Match(field);
                builder.BuilderMethods[match.Groups[1].Value](match.Groups[3].Value);
            }
            Console.WriteLine($"{builder.GetObject()}");
            repos[nameClass].AddToRepo(builder.GetObject());
        }
    }
}
