using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class CalendarioEleccionesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/CalendarioElecciones");
        private readonly HttpClient client;
        public CalendarioEleccionesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: CalendarioEleccionesController
        public ActionResult Index()
        {
            List<CalendarioElecciones> calendarios = new List<CalendarioElecciones>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                calendarios = JsonConvert.DeserializeObject<List<CalendarioElecciones>>(data);
            }
            return View(calendarios);
        }

        // GET: CalendarioEleccionesController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CalendarioElecciones calendario = new CalendarioElecciones();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    calendario = JsonConvert.DeserializeObject<CalendarioElecciones>(data);
                }
                return View(calendario);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CalendarioEleccionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarioEleccionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CalendarioElecciones calendario)
        {
            try
            {
                string data = JsonConvert.SerializeObject(calendario);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Calendario de elecciones creado con éxito.";
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CalendarioEleccionesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CalendarioElecciones calendario = new CalendarioElecciones();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    calendario = JsonConvert.DeserializeObject<CalendarioElecciones>(data);
                }
                return View(calendario);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: CalendarioEleccionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CalendarioElecciones calendario)
        {
            try
            {
                string data = JsonConvert.SerializeObject(calendario);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Calendario de elecciones actualizido con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: CalendarioEleccionesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CalendarioElecciones calendario = new CalendarioElecciones();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    calendario = JsonConvert.DeserializeObject<CalendarioElecciones>(data);

                }

                return View(calendario);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: CalendarioEleccionesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Calendario de elecciones eliminado con éxito";
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
