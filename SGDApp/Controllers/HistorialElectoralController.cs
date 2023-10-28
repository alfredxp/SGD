using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class HistorialElectoralController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/HistorialElectorals");
        private readonly HttpClient client;

        public HistorialElectoralController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: HistorialElectoralController
        public ActionResult Index()
        {
            List<HistorialElectoral> historials = new List<HistorialElectoral>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                historials = JsonConvert.DeserializeObject<List<HistorialElectoral>>(data);
            }
            return View(historials);
        }

        // GET: HistorialElectoralController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                HistorialElectoral historial = new HistorialElectoral();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    historial = JsonConvert.DeserializeObject<HistorialElectoral>(data);
                }
                return View(historial);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: HistorialElectoralController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialElectoralController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistorialElectoral electoral)
        {
            try
            {
                string data = JsonConvert.SerializeObject(electoral);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Historial electoral creado con éxito.";
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

        // GET: HistorialElectoralController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                HistorialElectoral electoral = new HistorialElectoral();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    electoral = JsonConvert.DeserializeObject<HistorialElectoral>(data);
                }
                return View(electoral);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: HistorialElectoralController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HistorialElectoral electoral)
        {
            try
            {
                string data = JsonConvert.SerializeObject(electoral);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Historial electoral actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: HistorialElectoralController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                HistorialElectoral electoral = new HistorialElectoral();    
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    electoral = JsonConvert.DeserializeObject<HistorialElectoral>(data);

                }

                return View(electoral);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: HistorialElectoralController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Historial electoral eliminado con éxito";
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
