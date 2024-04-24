using Avalonia.Controls;
using OODProj.AbstractFactories;
using OODProj.Data;
using OODProj.DataSources.MessageConvertors;
using OODProj.IDManagement;
using OODProj.Repository;
using OODProj.Utilities;
using NSS = NetworkSourceSimulator;
using OODProj.ApplicationConfiguration;
namespace OODProj.DataSources
{
    public class ByteDownloader : IDataDownloader
    {
        private ByteDownloaderSettings _settings;
        private Thread _server;

        public ByteDownloader(DownloaderSettings settings)
        {
            _settings = (ByteDownloaderSettings)settings;
            NSS.NetworkSourceSimulator network = new(_settings.SourceFile,1,5);
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

                string[] data = _settings.Convertors[classID].ConvertToStrings(currentMessage);

                var primaryKeyedObject = _settings.Factories[classID].SetObjectData(data).Create();
                if (_settings.ReportableIDs.Contains(classID))
                    _settings.Reportables.Add((IReportable)primaryKeyedObject);
                if (classID == "AI")
                    _settings.Managers[classID].AddPrimaryKeyedObject(primaryKeyedObject);
                _settings.Repositories[classID].AddToRepo(primaryKeyedObject);
                _settings.Factories[classID].ResetObjectData();
            }
        }
    }
}
