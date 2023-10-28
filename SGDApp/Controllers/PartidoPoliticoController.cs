using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class PartidoPoliticoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/PartidoPoliticoes");
        private readonly HttpClient client;

        public PartidoPoliticoController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: PartidoPoliticoController
        public ActionResult Index()
        {
            List<PartidoPolitico> areaList = new List<PartidoPolitico>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                areaList = JsonConvert.DeserializeObject<List<PartidoPolitico>>(data);
            }
            return View(areaList);
        }

        // GET: PartidoPoliticoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PartidoPolitico partido = new PartidoPolitico();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    partido = JsonConvert.DeserializeObject<PartidoPolitico>(data);
                }
                return View(partido);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: PartidoPoliticoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartidoPoliticoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartidoPolitico partido)
        {
            try
            {
                string data = JsonConvert.SerializeObject(partido);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Partido creado con éxito.";
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

        // GET: PartidoPoliticoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PartidoPolitico partido = new PartidoPolitico();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    partido = JsonConvert.DeserializeObject<PartidoPolitico>(data);
                }
                return View(partido);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: PartidoPoliticoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PartidoPolitico partido)
        {
            try
            {
                string data = JsonConvert.SerializeObject(partido);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Partido actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: PartidoPoliticoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PartidoPolitico partido = new PartidoPolitico();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    partido = JsonConvert.DeserializeObject<PartidoPolitico>(data);

                }

                return View(partido);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: PartidoPoliticoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Partido eliminado con éxito";
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
