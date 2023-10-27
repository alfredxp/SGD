using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;

namespace SGDApp.Controllers
{
    public class ComentarioController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Comentarios");
        private readonly HttpClient client;
        public ComentarioController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: ComentarioController
        public ActionResult Index()
        {
            List<Comentario> comentarios = new List<Comentario>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                comentarios = JsonConvert.DeserializeObject<List<Comentario>>(data);
            }
            return View(comentarios);
        }

        // GET: ComentarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Comentario comentario = new Comentario();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comentario = JsonConvert.DeserializeObject<Comentario>(data);
                }
                return View(comentario);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ComentarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comentario comentario)
        {
            try
            {
                string data = JsonConvert.SerializeObject(comentario);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Comentario creado con éxito.";
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

        // GET: ComentarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Comentario comentario = new Comentario();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    comentario = JsonConvert.DeserializeObject<Comentario>(data);
                }
                return View(comentario);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ComentarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comentario comentario)
        {
            try
            {
                string data = JsonConvert.SerializeObject(comentario);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Comentario actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ComentarioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Comentario area = new Comentario();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    area = JsonConvert.DeserializeObject<Comentario>(data);

                }

                return View(area);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: ComentarioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Comentario eliminado con éxito";
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
