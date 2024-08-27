using Agent_mvc.Service;
using Agent_mvc.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agent_mvc.Controllers
{
    public class CalculationController(ApiService apiService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var index = await apiService.Index();
                return View(index);
        }
    }
}
