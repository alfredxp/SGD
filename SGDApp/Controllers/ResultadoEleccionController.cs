using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class ResultadoEleccionController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/ResultadoEleccions");
        private readonly HttpClient client;

        public ResultadoEleccionController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: ResultadoEleccionController
        public ActionResult Index()
        {
            List<ResultadoEleccion> resultadoEleccions = new List<ResultadoEleccion>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                resultadoEleccions = JsonConvert.DeserializeObject<List<ResultadoEleccion>>(data);
            }
            return View(resultadoEleccions);
        }

        // GET: ResultadoEleccionController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ResultadoEleccion resultadoEleccion = new ResultadoEleccion();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    resultadoEleccion = JsonConvert.DeserializeObject<ResultadoEleccion>(data);
                }
                return View(resultadoEleccion);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ResultadoEleccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultadoEleccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResultadoEleccion resultado)
        {
            try
            {
                string data = JsonConvert.SerializeObject(resultado);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Resultado eleccion creado con éxito.";
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

        // GET: ResultadoEleccionController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ResultadoEleccion resultado = new ResultadoEleccion();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<ResultadoEleccion>(data);
                }
                return View(resultado);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ResultadoEleccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResultadoEleccion resultado)
        {
            try
            {
                string data = JsonConvert.SerializeObject(resultado);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Resultado elección actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ResultadoEleccionController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ResultadoEleccion resultado = new ResultadoEleccion();  
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    resultado = JsonConvert.DeserializeObject<ResultadoEleccion>(data);

                }

                return View(resultado);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ResultadoEleccionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Resultado elección eliminado con éxito";
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
