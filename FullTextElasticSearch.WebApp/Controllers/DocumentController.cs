using FullTextElasticSearch.Services.Implementations;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FullTextElasticSearch.WebApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DocumentService _documentService = new DocumentService();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Reload()
        {
            await _documentService.RestoreIndex();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public ActionResult Update()
        {
            DateTime? data;
            _documentService.UpdateDocuments(out data);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
} 