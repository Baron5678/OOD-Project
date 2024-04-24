using OODProj.ApplicationConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OODProj.Logging
{
    public sealed class Log
    {
        private static readonly Lazy<Log> _log = new(() => new Log());
        public static Log Instance { get => _log.Value; }

        private static int _id = 0;

        public string GenerateSha256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GetLogFilePath()
        {
            string directoryPath = @"..\..\..\Logging\LogFiles\";

            string fileName = $"Log_{DateTime.Now:yyyy-MM-dd}.txt";
            return Path.Combine(directoryPath, fileName);
        }

        public void LogWrite<T>(State<T> state)
        {
            string line = $"-------------{GenerateSha256Hash(_id.ToString())}-------------\n\n" +
                $"{state}";
            File.AppendAllText(GetLogFilePath(), line + Environment.NewLine);
            _id++;
        }

        public void LogWrite(ErrorState errorState)
        {
            string line = $"-------------{GenerateSha256Hash(_id.ToString())}-------------\n\n" +
                $"{errorState}\n";
            File.AppendAllText(GetLogFilePath(), line + Environment.NewLine);
            _id++;
        }

        public static void LogClear() { File.WriteAllText(@$"..\..\..\Logging\LogFiles\Log", string.Empty);}
    }
}
