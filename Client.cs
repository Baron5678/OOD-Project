using OODProj.DataSourceManager;

namespace OODProj
{
    internal class Client
    {  
        static void Main(string[] args)
        {
            ApplicationManager app = ApplicationManager.Instance;

            app.LoadNetworkData();

            app.StartCommandInterpreter();

        }
    }
}

