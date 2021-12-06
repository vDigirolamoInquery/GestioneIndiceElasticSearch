using System.ServiceProcess;

namespace FullTextElasticSearch.WinService
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Main()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
