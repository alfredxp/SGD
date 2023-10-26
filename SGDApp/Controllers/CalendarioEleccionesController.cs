using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class CalendarioEleccionesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;
        public CalendarioEleccionesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: CalendarioEleccionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CalendarioEleccionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalendarioEleccionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarioEleccionesController/Create
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

        // GET: CalendarioEleccionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalendarioEleccionesController/Edit/5
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

        // GET: CalendarioEleccionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalendarioEleccionesController/Delete/5
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
