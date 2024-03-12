using OODProj.AbstarctFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Repository;
using NetworkSourceSimulator;
using OODProj.Builders;
using OODProj.Builders.PlanesBuilders;
using OODProj.Builders.Directors;
namespace OODProj.StrategiesGettingData.DataReaders
{
    internal class NetworkReader : IReader
    {
        private Dictionary<string, IDirector> _directories;

        private Dictionary<string, IRepository> _repos;

        public Message Message { get; set; }

        public NetworkReader(Dictionary<string, IDirector> directories, Dictionary<string, IRepository> repos)
            => (_directories, _repos, Message) = (directories, repos, default);

        public void Read()
        {
            StringBuilder s = new();

            foreach (byte item in Message.MessageBytes[1..3])
            {
                s.Append((char)item);

                switch (s.ToString())
                {
                    case "CR":
                        s.Remove(1, 1);
                        break;
                    case "PA":
                        s.Remove(1, 1);                        
                        break;
                }
            }

            _repos[s.ToString()].AddToRepo(_directories[s.ToString()].Construct(Message.MessageBytes).GetResult());
        }

        private string BytesToString(byte[] bytes)
        {
            StringBuilder s = new();
            foreach (byte item in bytes)
            {
                s.Append((char)item);
            }
            return s.ToString();
        }
    }
}
