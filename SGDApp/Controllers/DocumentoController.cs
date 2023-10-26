using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class DocumentoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;
        public DocumentoController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: DocumentoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
