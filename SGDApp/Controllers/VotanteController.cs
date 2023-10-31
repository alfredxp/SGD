using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class VotanteController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Votantes");
        private readonly HttpClient client;

        public VotanteController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: VotanteController
        public ActionResult Index()
        {
            List<Votante> votantes = new List<Votante>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                votantes = JsonConvert.DeserializeObject<List<Votante>>(data);
            }
            return View(votantes);
        }

        // GET: VotanteController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Votante votante = new Votante();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    votante = JsonConvert.DeserializeObject<Votante>(data);
                }
                return View(votante);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: VotanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VotanteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Votante votante)
        {
            try
            {
                string data = JsonConvert.SerializeObject(votante);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Votante creado con éxito.";
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

        // GET: VotanteController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Votante votante = new Votante();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    votante = JsonConvert.DeserializeObject<Votante>(data);
                }
                return View(votante);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: VotanteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Votante votante)
        {
            try
            {
                string data = JsonConvert.SerializeObject(votante);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Votante actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: VotanteController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Votante votante = new Votante();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    votante = JsonConvert.DeserializeObject<Votante>(data);

                }

                return View(votante);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: VotanteController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Votante eliminado con éxito";
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
