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
            //Log.LogClear();
            app.LoadFTRData();
            app.StartGUIAsync();
            //Thread.Sleep(10000);
            //app.UpdateData();
            app.StartCommandInterpreter();
            
        } 
    }
}

