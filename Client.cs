using OODProj.ApplicationConfiguration;
using OODProj.Logging;


namespace OODProj
{
    public class A 
    {
        public int prop = 1;
    }

    internal class Client
    {  
        static void Main(string[] args)
        {
            ApplicationManager app = ApplicationManager.Instance;
            Log.LogClear();
            //app.LoadNetworkData();
            app.LoadFTRData();
            //app.StartGUIAsync();
            //Thread.Sleep(10000);
            app.UpdateData();
            //app.ShowLoadedData();
            app.StartCommandInterpreter();
        } 
    }
}

