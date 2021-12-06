using FullTextElasticSearch.Log4Net;
using FullTextElasticSearch.Services.Implementations;
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;

namespace FullTextElasticSearch.WinService
{
    public partial class Main : ServiceBase
    {
        private readonly Logger<Main> Logger = new Logger<Main>();
        private readonly Timer TimerAggiornaIndice = new Timer();

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Logger.Info("Servizio avviato");

                var timerIntervalSetting = ConfigurationManager.AppSettings["Timer.Interval"];
                int interval;

                if (int.TryParse(timerIntervalSetting, out interval))
                {
                    TimerAggiornaIndice.Interval = interval;
                    Logger.Info(string.Format("Timer impostato ogni {0} secondi", (interval / 1000)));
                    TimerAggiornaIndice.Enabled = true;
                    TimerAggiornaIndice.Elapsed += TimerAggiornaIndice_Tick;
                }
                else
                {
                    Logger.Error(string.Format("Timer non impostato. Valore Interval: {0}", interval));
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Servizio non avviato", ex);
            }
        }

        protected override void OnStop()
        {
            Logger.Info("Servizio arrestato");
        }
        
        private void TimerAggiornaIndice_Tick(object sender, EventArgs e)
        {
            TimerAggiornaIndice.Enabled = false;
            Logger.Info("Aggiornamento documenti avviato");
            DocumentService ds = new DocumentService();
            try
            {
                DateTime? dataUltimoAggiornamento;
                ds.UpdateDocuments(out dataUltimoAggiornamento);
                Logger.Info("Aggiornamento documenti completato");
                
                if (dataUltimoAggiornamento.HasValue) //BDC-415
                {
                    ds.AggiornaData(dataUltimoAggiornamento.Value);
                    Logger.Info(string.Format("Aggiornamento data con valore {0}", dataUltimoAggiornamento.Value.ToString("dd/MM/yyyy HH:mm:ss.ffff")));
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Aggiornamento documenti non completato", ex);
            }
            TimerAggiornaIndice.Enabled = true;
        }
    }
}
