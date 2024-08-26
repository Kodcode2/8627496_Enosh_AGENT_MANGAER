using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Agent_mvc.ViewModel;


namespace Agent_mvc.Controllers
{
    public class MissionsController(IHttpClientFactory clientFactory) : Controller
    {
        private static string BaseUrl = "https://localhost:7017/";

        public async Task<IActionResult> Index()
        {
            var httpClient = clientFactory.CreateClient();
            var result = await httpClient.GetAsync(BaseUrl + "missions");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                List<MissionVM>? missions = JsonSerializer.Deserialize<List<MissionVM>>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                return View(missions);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

