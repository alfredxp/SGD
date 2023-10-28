using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class EleccionesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Eleciones");
        private readonly HttpClient client;
        public EleccionesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: EleccionesController
        public ActionResult Index()
        {
            List<Elecciones> elecciones = new List<Elecciones>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                elecciones = JsonConvert.DeserializeObject<List<Elecciones>>(data);
            }
            return View(elecciones);
        }

        // GET: EleccionesController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Elecciones elecciones = new Elecciones();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    elecciones = JsonConvert.DeserializeObject<Elecciones>(data);
                }
                return View(elecciones);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: EleccionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EleccionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Elecciones elecciones)
        {
            try
            {
                string data = JsonConvert.SerializeObject(elecciones);
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

        // GET: EleccionesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Elecciones elecciones = new Elecciones();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    elecciones = JsonConvert.DeserializeObject<Elecciones>(data);
                }
                return View(elecciones);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: EleccionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Elecciones elecciones)
        {
            try
            {
                string data = JsonConvert.SerializeObject(elecciones);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Elección actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: EleccionesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Elecciones area = new Elecciones();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    area = JsonConvert.DeserializeObject<Elecciones>(data);

                }

                return View(area);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: EleccionesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Elección eliminado con éxito";
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
