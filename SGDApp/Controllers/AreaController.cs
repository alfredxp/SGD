using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGDApp.Models;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;

namespace SGDApp.Controllers
{
   
    public class AreaController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api/Areas");
        private readonly HttpClient client;

        public AreaController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: AreaController
        public ActionResult Index()
        {
            List<Area> areaList = new List<Area>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                areaList = JsonConvert.DeserializeObject<List<Area>>(data);
            }
            return View(areaList);
        }

        // GET: AreaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Area area = new Area();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/"+ id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    area = JsonConvert.DeserializeObject<Area>(data);
                }
                return View(area);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: AreaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Area area)
        {
            try
            {
                string data = JsonConvert.SerializeObject(area);
                StringContent stringContent = new StringContent(data, encoding: Encoding.UTF8,"application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress , stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Area creado con éxito.";
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: AreaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Area area = new Area();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    area = JsonConvert.DeserializeObject<Area>(data);
                }
                return View(area);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: AreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Area area)
        {
            try
            {
                string data = JsonConvert.SerializeObject(area);
                StringContent content= new StringContent(data,Encoding.UTF8,"application/json");
                HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress , content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Area actualizado con éxito.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: AreaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Area area = new Area();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode) { 
                    string data = response.Content.ReadAsStringAsync().Result;
                    area = JsonConvert.DeserializeObject<Area>(data);

                }

                return View(area);
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
        }

        // POST: AreaController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Area eliminado con éxito";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
