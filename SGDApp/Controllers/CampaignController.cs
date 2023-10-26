using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SGDApp.Controllers
{
    public class CampaignController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        private readonly HttpClient client;
        public CampaignController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: CampaignController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CampaignController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CampaignController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampaignController/Create
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

        // GET: CampaignController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CampaignController/Edit/5
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

        // GET: CampaignController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CampaignController/Delete/5
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
