using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class LogActividadesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;

        public LogActividadesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: LogActividadesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LogActividadesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LogActividadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogActividadesController/Create
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

        // GET: LogActividadesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogActividadesController/Edit/5
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

        // GET: LogActividadesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogActividadesController/Delete/5
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
