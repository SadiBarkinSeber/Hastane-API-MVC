using CORSUygulama.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CORSUygulama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client;
        private readonly string adres = "https://localhost:7213/api/Hastane";
        public HomeController(ILogger<HomeController> logger)
        {
            client = new HttpClient();
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            
            //var response = await client.GetAsync("https://localhost:7070/api/Student/GetAllStudents");

           

            //var json = await response.Content.ReadAsStringAsync();
            //List<HastaneVM> hastaneList = JsonConvert.DeserializeObject<List<HastaneVM>>(json);

            return View();
        }

        public async Task<IActionResult> Update(int id = 1)
        {
            HastaneVM hastaneVM = await client.GetFromJsonAsync<HastaneVM>(adres + "/" + id);

            hastaneVM.HastaneAdi = "Uskudar Devlet Hastanesi";
            hastaneVM.Adres = "Uskudar";
            
            var result = await client.PutAsJsonAsync(adres + "/" + id, hastaneVM);

            return View();
        }

        public async Task<IActionResult> Delete(int id = 1)
        {

            var result = await client.DeleteAsync(adres + "/" + id);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Hata", "Silinirken hata olustu!");
            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}