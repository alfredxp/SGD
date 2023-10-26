using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class VotingRecord : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;

        public VotingRecord()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: VotanteRecordsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VotanteRecordsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VotanteRecordsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VotanteRecordsController/Create
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

        // GET: VotanteRecordsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VotanteRecordsController/Edit/5
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

        // GET: VotanteRecordsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VotanteRecordsController/Delete/5
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
