using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class CandidatoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Candidatoes");
        private readonly HttpClient client;
        public CandidatoController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: CandidatoController
        public ActionResult Index()
        {
            List<Candidato> candidatos = new List<Candidato>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                candidatos = JsonConvert.DeserializeObject<List<Candidato>>(data);
            }
            return View(candidatos);
        }

        // GET: CandidatoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Candidato candidato = new Candidato();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    candidato = JsonConvert.DeserializeObject<Candidato>(data);
                }
                return View(candidato);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CandidatoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidato candidato)
        {
            try
            {
                string data = JsonConvert.SerializeObject(candidato);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Candidato creada con éxito.";
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

        // GET: CandidatoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Candidato candidato = new Candidato();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    candidato = JsonConvert.DeserializeObject<Candidato>(data);
                }
                return View(candidato);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: CandidatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidato candidato)
        {
            try
            {
                string data = JsonConvert.SerializeObject(candidato);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Candidato actualizido con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CandidatoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Candidato area = new Candidato();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    area = JsonConvert.DeserializeObject<Candidato>(data);
                }

                return View(area);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: CandidatoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DelDeleteConfirmedete(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Candidato eliminado con éxito";
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
