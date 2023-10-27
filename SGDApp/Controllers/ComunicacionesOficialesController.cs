using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class ComunicacionesOficialesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/ComunicacionesOficiales");
        private readonly HttpClient client;
        public ComunicacionesOficialesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: ComunicacionesOficialesController
        public ActionResult Index()
        {
            List<ComunicacionesOficiales> comunicaciones = new List<ComunicacionesOficiales>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                comunicaciones = JsonConvert.DeserializeObject<List<ComunicacionesOficiales>>(data);
            }
            return View(comunicaciones);
        }

        // GET: ComunicacionesOficialesController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ComunicacionesOficiales comunicaciones = new ComunicacionesOficiales();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comunicaciones = JsonConvert.DeserializeObject<ComunicacionesOficiales>(data);
                }
                return View(comunicaciones);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ComunicacionesOficialesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComunicacionesOficialesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComunicacionesOficiales comunicaciones)
        {
            try
            {
                string data = JsonConvert.SerializeObject(comunicaciones);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Comunicación oficial creada con éxito.";
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

        // GET: ComunicacionesOficialesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ComunicacionesOficiales comunicaciones = new ComunicacionesOficiales();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comunicaciones = JsonConvert.DeserializeObject<ComunicacionesOficiales>(data);
                }
                return View(comunicaciones);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ComunicacionesOficialesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComunicacionesOficiales comunicaciones)
        {
            try
            {
                string data = JsonConvert.SerializeObject(comunicaciones);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Comunicación oficial actualizada con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ComunicacionesOficialesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ComunicacionesOficiales comunicaciones = new ComunicacionesOficiales();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comunicaciones = JsonConvert.DeserializeObject<ComunicacionesOficiales>(data);

                }

                return View(comunicaciones);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ComunicacionesOficialesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Comunicación oficial eliminada con éxito";
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
