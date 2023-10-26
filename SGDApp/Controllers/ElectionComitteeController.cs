using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class ElectionComitteeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;

        public ElectionComitteeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: ElectionComitteeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ElectionComitteeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElectionComitteeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectionComitteeController/Create
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

        // GET: ElectionComitteeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ElectionComitteeController/Edit/5
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

        // GET: ElectionComitteeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ElectionComitteeController/Delete/5
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
