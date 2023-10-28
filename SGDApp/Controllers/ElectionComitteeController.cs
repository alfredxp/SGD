using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class ElectionComitteeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/ElectionComittees");
        private readonly HttpClient client;

        public ElectionComitteeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: ElectionComitteeController
        public ActionResult Index()
        {
            List<ElectionComittee> electionComittees = new List<ElectionComittee>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                electionComittees = JsonConvert.DeserializeObject<List<ElectionComittee>>(data);
            }
            return View(electionComittees);
        }

        // GET: ElectionComitteeController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ElectionComittee election = new ElectionComittee();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    election = JsonConvert.DeserializeObject<ElectionComittee>(data);
                }
                return View(election);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ElectionComitteeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectionComitteeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ElectionComittee election)
        {
            try
            {
                string data = JsonConvert.SerializeObject(election);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Elección creada con éxito.";
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

        // GET: ElectionComitteeController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ElectionComittee election = new ElectionComittee(); 
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    election = JsonConvert.DeserializeObject<ElectionComittee>(data);
                }
                return View(election);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ElectionComitteeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ElectionComittee election)
        {
            try
            {
                string data = JsonConvert.SerializeObject(election);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Elección actualizada con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ElectionComitteeController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ElectionComittee election = new ElectionComittee();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    election = JsonConvert.DeserializeObject<ElectionComittee>(data);

                }

                return View(election);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ElectionComitteeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Elección eliminada con éxito";
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
