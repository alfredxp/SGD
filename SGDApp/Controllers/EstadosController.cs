using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class EstadosController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Estados");
        private readonly HttpClient client;

        public EstadosController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: EstadosController
        public ActionResult Index()
        {
            List<Estados> estados = new List<Estados>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                estados = JsonConvert.DeserializeObject<List<Estados>>(data);
            }
            return View(estados);
        }

        // GET: EstadosController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Estados estados = new Estados();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<Estados>(data);
                }
                return View(estados);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: EstadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estados estados)
        {
            try
            {
                string data = JsonConvert.SerializeObject(estados);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Estado creado con éxito.";
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

        // GET: EstadosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Estados estados = new Estados();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    estados = JsonConvert.DeserializeObject<Estados>(data);
                }
                return View(estados);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: EstadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estados estados)
        {
            try
            {
                string data = JsonConvert.SerializeObject(estados);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Estado actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: EstadosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Estados es = new Estados();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    es = JsonConvert.DeserializeObject<Estados>(data);

                }

                return View(es);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: EstadosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Estado eliminado con éxito";
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
