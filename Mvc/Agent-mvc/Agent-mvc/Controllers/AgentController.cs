using Agent_mvc.Service;
using Agent_mvc.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agent_mvc.Controllers
{
    public class AgentController(IHttpClientFactory clientFactory) : Controller
    {
        private static string BaseUrl = "https://localhost:7017/";

        public async Task<IActionResult> Index()
        {
            var httpClient = clientFactory.CreateClient();
            var result = await httpClient.GetAsync(BaseUrl + "agents");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                List<AgentVM>? agents = JsonSerializer.Deserialize<List<AgentVM>>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                return View(agents);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
