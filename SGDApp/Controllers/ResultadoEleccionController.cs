using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class ResultadoEleccionController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;

        public ResultadoEleccionController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: ResultadoEleccionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ResultadoEleccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResultadoEleccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultadoEleccionController/Create
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

        // GET: ResultadoEleccionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResultadoEleccionController/Edit/5
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

        // GET: ResultadoEleccionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResultadoEleccionController/Delete/5
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
