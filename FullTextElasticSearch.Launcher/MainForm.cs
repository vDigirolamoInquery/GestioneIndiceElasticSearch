using FullTextElasticSearch.Log4Net;
using FullTextElasticSearch.Services.Implementations;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace FullTextElasticSearch.Launcher
{
    public partial class MainForm : Form
    {
        private readonly Logger<MainForm> Logger = new Logger<MainForm>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreaNuovoIndice_Click(object sender, EventArgs e)
        {
            Logger.Info("Avvio creazione indice");
            textBox1.Text = "inizio\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            try
            {
                DocumentService ds = new DocumentService();
                ds.CreaNuovoIndice();
            }
            catch (Exception ex)
            {
                textBox1.Text += "errore\r\n";
                textBox1.Text += ex.Message + "\r\n";
                textBox1.Text += ex.StackTrace + "\r\n";
                textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
                Logger.Error("Errore", ex);
            }
            textBox1.Text += "fine\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            Logger.Info("Fine generazione indice");
        }

        private void btnImportaDaStored_Click(object sender, EventArgs e)
        {
            Logger.Info("Avvio indicizzazione documenti");
            textBox1.Text = "inizio\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            try
            {
                DocumentService ds = new DocumentService();
                string prodotto = ConfigurationManager.AppSettings["FullText.Prodotto"];
                ds.IndicizzaDocumenti(int.Parse(prodotto));
            }
            catch (Exception ex)
            {
                textBox1.Text += "errore\r\n";
                textBox1.Text += ex.Message + "\r\n";
                textBox1.Text += ex.StackTrace + "\r\n";
                textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
                Logger.Error("Errore", ex);
            }
            textBox1.Text += "fine\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            Logger.Info("Fine indicizzazione documenti");
        }

        private void btnImportaSacdenzeDaStored_Click(object sender, EventArgs e)
        {
            Logger.Info("Avvio indicizzazione scadenze");
            textBox1.Text = "inizio\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            try
            {
                DocumentService ds = new DocumentService();
                string prodotto = ConfigurationManager.AppSettings["FullText.Prodotto"];
                ds.IndicizzaScadenze(int.Parse(prodotto));
            }
            catch (Exception ex)
            {
                textBox1.Text += "errore\r\n";
                textBox1.Text += ex.Message + "\r\n";
                textBox1.Text += ex.StackTrace + "\r\n";
                textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
                Logger.Error("Errore", ex);
            }
            textBox1.Text += "fine\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            Logger.Info("Fine indicizzazione scadenze");
        }
        private void btnAggiornaDocumento_Click(object sender, EventArgs e)
        {
            Logger.Info("Avvio aggiornamento documento");
            textBox1.Text = "inizio\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            try
            {
                DocumentService ds = new DocumentService();
                ds.AggiornaDocumento(tbIdDocumento.Text.Trim());
            }
            catch (Exception ex)
            {
                textBox1.Text += "errore\r\n";
                textBox1.Text += ex.Message + "\r\n";
                textBox1.Text += ex.StackTrace + "\r\n";
                textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
                Logger.Error("Errore", ex);
            }
            textBox1.Text += "fine\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            Logger.Info("Fine aggiornamento documento");
        }

        private void btnEliminaDocumento_Click(object sender, EventArgs e)
        {
            Logger.Info("Avvio eliminazione documento");
            textBox1.Text = "inizio\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            try
            {
                DocumentService ds = new DocumentService();
                ds.EliminaDocumento(tbIdDocumento.Text.Trim());
            }
            catch (Exception ex)
            {
                textBox1.Text += "errore\r\n";
                textBox1.Text += ex.Message + "\r\n";
                textBox1.Text += ex.StackTrace + "\r\n";
                textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
                Logger.Error("Errore", ex);
            }
            textBox1.Text += "fine\r\n";
            textBox1.Text += DateTime.Now.ToShortTimeString() + "\r\n";
            Logger.Info("Fine eliminazione documento");
        }

    }
}
