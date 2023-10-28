using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class LogActividadesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/LogActividades");
        private readonly HttpClient client;

        public LogActividadesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: LogActividadesController
        public ActionResult Index()
        {
            List<LogActividades> logActividades = new List<LogActividades>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                logActividades = JsonConvert.DeserializeObject<List<LogActividades>>(data);
            }
            return View(logActividades);
        }

        // GET: LogActividadesController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                LogActividades logActividades = new LogActividades();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    logActividades = JsonConvert.DeserializeObject<LogActividades>(data);
                }
                return View(logActividades);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: LogActividadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogActividadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogActividades logActividades)
        {
            try
            {
                string data = JsonConvert.SerializeObject(logActividades);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "LogActividades creado con éxito.";
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

        // GET: LogActividadesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                LogActividades logActividades = new LogActividades();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    logActividades = JsonConvert.DeserializeObject<LogActividades>(data);
                }
                return View(logActividades);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: LogActividadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LogActividades logActividades)
        {
            try
            {
                string data = JsonConvert.SerializeObject(logActividades);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Log de actividad actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: LogActividadesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                LogActividades logActividades = new LogActividades();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    logActividades = JsonConvert.DeserializeObject<LogActividades>(data);

                }

                return View(logActividades);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: LogActividadesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Log de actividad eliminado con éxito";
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
