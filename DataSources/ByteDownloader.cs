using Avalonia.Controls;
using OODProj.AbstractFactories;
using OODProj.DataSources.MessageConvertors;
using OODProj.Repository;
using OODProj.Utilities;
using NSS = NetworkSourceSimulator;

namespace OODProj.DataSources
{
    public class ByteDownloader : IDataDownloader
    {
        private readonly string _path = string.Empty;
        private readonly Dictionary<string, IFactory> _factories;
        private readonly Dictionary<string, IRepository> _repos;
        private readonly Dictionary<string, IMessageConvertor> _convertors;

        private Thread _server;

        public ByteDownloader(string path,
                              Dictionary<string, IFactory> factories,
                              Dictionary<string, IRepository> repos,
                              Dictionary<string, IMessageConvertor> convertors)
        {
            _path = path;
            _factories = factories;
            _repos = repos;
            _convertors = convertors;

            NSS.NetworkSourceSimulator network = new(_path, 100, 500);
            network.OnNewDataReady += DownloadMessage;
            _server = new Thread(network.Run);
            _server.IsBackground = true;
        }

        public void Download() 
            => _server.Start();
        
        private void DownloadMessage(object sender, NSS.NewDataReadyArgs e)
        {
            var currentNetwork = sender as NSS.NetworkSourceSimulator;

            if (currentNetwork is not null)
            {
                byte[] currentMessage = currentNetwork.GetMessageAt(e.MessageIndex).MessageBytes;
                
                string classID = Utility.BytesToString(currentMessage[1..3]);

                if (classID == "PA")
                    classID.Remove(1, 1);
                
                if (classID == "CR")
                    classID.Remove(1, 1);

                string[] data = _convertors[classID].ConvertToStrings(currentMessage);

                _repos[classID].AddToRepo(_factories[classID].SetObjectData(data).Create());

                _factories[classID].ResetObjectData();

            }
        }
    }
}
