using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class CampaignController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/CampaignDocuments");
        private readonly HttpClient client;
        public CampaignController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: CampaignController
        public ActionResult Index()
        {
            List<CampaignDocument> campaignList = new List<CampaignDocument>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                campaignList = JsonConvert.DeserializeObject<List<CampaignDocument>>(data);
            }
            return View(campaignList);
        }

        // GET: CampaignController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CampaignDocument campaign = new CampaignDocument();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    campaign = JsonConvert.DeserializeObject<CampaignDocument>(data);
                }
                return View(campaign);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CampaignController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampaignController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CampaignDocument campaign)
        {
            try
            {
                string data = JsonConvert.SerializeObject(campaign);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Documento creado con éxito.";
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CampaignController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CampaignDocument campaign = new CampaignDocument();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    campaign = JsonConvert.DeserializeObject<CampaignDocument>(data);
                }
                return View(campaign);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: CampaignController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CampaignDocument  campaign)
        {
            try
            {
                string data = JsonConvert.SerializeObject(campaign);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Documento actualizida con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CampaignController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CampaignDocument campaign = new CampaignDocument();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    campaign = JsonConvert.DeserializeObject<CampaignDocument>(data);

                }

                return View(campaign);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: CampaignController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Documento eliminado con éxito";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
