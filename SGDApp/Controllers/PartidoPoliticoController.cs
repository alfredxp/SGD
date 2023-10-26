using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class PartidoPoliticoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;

        public PartidoPoliticoController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: PartidoPoliticoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PartidoPoliticoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PartidoPoliticoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartidoPoliticoController/Create
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

        // GET: PartidoPoliticoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PartidoPoliticoController/Edit/5
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

        // GET: PartidoPoliticoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartidoPoliticoController/Delete/5
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
