using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SGDApp.Controllers
{
    public class VotingRecord : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/VotingRecords");
        private readonly HttpClient client;

        public VotingRecord()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: VotanteRecordsController
        public ActionResult Index()
        {
            List<VotingRecord> votings = new List<VotingRecord>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                votings = JsonConvert.DeserializeObject<List<VotingRecord>>(data);
            }
            return View(votings);
        }

        // GET: VotanteRecordsController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                VotingRecord votingRecord = new VotingRecord();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    votingRecord = JsonConvert.DeserializeObject<VotingRecord>(data);
                }
                return View(votingRecord);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: VotanteRecordsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VotanteRecordsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VotingRecord voting)
        {
            try
            {
                string data = JsonConvert.SerializeObject(voting);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Voting record creado con éxito.";
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

        // GET: VotanteRecordsController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                VotingRecord voting = new VotingRecord();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    voting = JsonConvert.DeserializeObject<VotingRecord>(data);
                }
                return View(voting);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: VotanteRecordsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VotingRecord voting)
        {
            try
            {
                string data = JsonConvert.SerializeObject(voting);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Voting record actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: VotanteRecordsController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                VotingRecord voting = new VotingRecord();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    voting = JsonConvert.DeserializeObject<VotingRecord>(data);

                }

                return View(voting);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: VotanteRecordsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Voting record eliminado con éxito";
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
