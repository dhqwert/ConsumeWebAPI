using Microsoft.AspNetCore.Mvc;
using StudentConsumeWebAPI.Models;

namespace StudentConsumeWebAPI.Controllers
{
    public class StudentsController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IHttpClientFactory _httpClientFactory;

        public StudentsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("http://localhost:5211/api/Students");

            if (response.IsSuccessStatusCode)
            {
                var students = await response.Content.ReadFromJsonAsync<IEnumerable<Student>>();
                return View("~/Views/Home/Index.cshtml", students); // Trỏ đến đúng View
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> UpdatePhoto(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var base64ImageString = "base64StringForImage"; // Chuỗi base64 của ảnh
            var response = await httpClient.PutAsJsonAsync($"http://localhost:5211/api/Students/UpdatePhoto/{id}", base64ImageString);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
    }
}
