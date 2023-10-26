using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class VotanteController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;

        public VotanteController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: VotanteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VotanteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VotanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VotanteController/Create
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

        // GET: VotanteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VotanteController/Edit/5
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

        // GET: VotanteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VotanteController/Delete/5
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
