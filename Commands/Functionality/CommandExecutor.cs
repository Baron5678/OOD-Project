using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OODProj.NewsReport;

namespace OODProj.Commands.Functionality
{
    public class CommandExecutor : IExecutor
    {
        public void Visit(Print printCommand, DataContainer data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText($@"..\..\..\DataFiles\JSON\snapshot_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.json", json);
        }

        public void Visit(Report printCommand, INewsIterator newsGenerator)
        {
            //if (newsGenerator.IsAllGenerated)
            //    Console.WriteLine("All news generated");
            while (!newsGenerator.IsAllGenerated) {
                Console.WriteLine(newsGenerator.GenerateNextNews());
            }
            Console.WriteLine(newsGenerator.CountNews);
            Console.WriteLine("All news generated");
        }
    }
}
