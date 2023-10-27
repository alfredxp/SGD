using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class DocumentoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Documentoes");
        private readonly HttpClient client;
        public DocumentoController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: DocumentoController
        public ActionResult Index()
        {
            List<Documento> documentos = new List<Documento>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                documentos = JsonConvert.DeserializeObject<List<Documento>>(data);
            }
            return View(documentos);
        }

        // GET: DocumentoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Documento documento = new Documento();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    documento = JsonConvert.DeserializeObject<Documento>(data);
                }
                return View(documento);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: DocumentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Documento documento)
        {
            try
            {
                string data = JsonConvert.SerializeObject(documento);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Documento creado con éxito.";
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

        // GET: DocumentoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Documento documento = new Documento();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    documento = JsonConvert.DeserializeObject<Documento>(data);
                }
                return View(documento);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: DocumentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Documento documento)
        {
            try
            {
                string data = JsonConvert.SerializeObject(documento);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Documento actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: DocumentoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Documento documento = new Documento();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    documento = JsonConvert.DeserializeObject<Documento>(data);

                }

                return View(documento);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: DocumentoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Documento eliminado con éxito";
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
