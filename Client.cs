using OODProj.ApplicationConfiguration;


namespace OODProj
{
    internal class Client
    {  
        static void Main(string[] args)
        {
            ApplicationManager app = ApplicationManager.Instance;
            app.LoadFTRData();
            app.StartGUIAsync();
            app.StartCommandInterpreter();
        }
    }
}

