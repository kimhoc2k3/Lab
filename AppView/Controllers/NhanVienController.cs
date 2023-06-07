using AppAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        public NhanVienController() { }
        
        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "http://localhost:5001/api/NhanViens/GetAll";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<NhanVienVM>>(apiData);
            return View(result);
        }

       
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhanVienVM nv)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var httpClient = new HttpClient();

            string apiURL = "http://localhost:5001/api/NhanViens/";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(nv);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"http://localhost:5001/api/NhanViens/nhanvien/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NhanVienVM>(apiData);
            return View(result);
        }
        
        public async Task<IActionResult> Edit(NhanVienVM nv)
        {
            if (!ModelState.IsValid) return View(ModelState);

            var httpClient = new HttpClient();
            string apiURL = $"http://localhost:5001/api/NhanViens/{nv.Id}";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(nv);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"http://localhost:5001/api/NhanViens/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai tiep roi be oi");
            return BadRequest();
        }

    }
}
