using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Text;
using Task = SGDApp.Models.Task;

namespace SGDApp.Controllers
{
    public class TaskController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Tasks");
        private readonly HttpClient client;

        public TaskController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: TaskController
        public ActionResult Index()
        {
            List<Task> tasks = new List<Task>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                tasks = JsonConvert.DeserializeObject<List<Task>>(data);
            }
            return View(tasks);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Task task = new Task();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    task = JsonConvert.DeserializeObject<Task>(data);
                }
                return View(task);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            try
            {
                string data = JsonConvert.SerializeObject(task);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress, stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Task creado con éxito.";
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

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Task task = new Task();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    task = JsonConvert.DeserializeObject<Task>(data);
                }
                return View(task);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            try
            {
                string data = JsonConvert.SerializeObject(task);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Task actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Task task = new Task();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    task = JsonConvert.DeserializeObject<Task>(data);

                }

                return View(task);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: TaskController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Task eliminado con éxito";
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
