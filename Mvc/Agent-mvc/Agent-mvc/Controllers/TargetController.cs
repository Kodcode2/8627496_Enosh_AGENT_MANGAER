using Agent_mvc.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agent_mvc.Controllers
{
    public class TargetController(IHttpClientFactory clientFactory) : Controller
    {
        private static string BaseUrl = "https://localhost:7017/";

        public async Task<IActionResult> Index()
        {
            var httpClient = clientFactory.CreateClient();
            var result = await httpClient.GetAsync(BaseUrl + "targets");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                List<TargetVM>? targets = JsonSerializer.Deserialize<List<TargetVM>>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                return View(targets);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
