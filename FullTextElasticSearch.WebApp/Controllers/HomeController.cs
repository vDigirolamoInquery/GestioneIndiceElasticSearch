using FullTextElasticSearch.Server;
using FullTextElasticSearch.WebApp.Models.ViewModels;
using System.Configuration;
using System.Web.Mvc;

namespace FullTextElasticSearch.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var esViewModel = new InformazioniIndiceESViewModel()
            {
                Indice = ConfigurationManager.AppSettings["ElasticSearch.DefaultIndex"],
                Server = ConfigurationManager.AppSettings["ElasticSearch.DefaultServer"],
                SeIndiceEsiste = new ConnectionToEs().IndexExists()
            };
            return View(esViewModel);
        }
    }
}