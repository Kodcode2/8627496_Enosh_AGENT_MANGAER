using Agent_mvc.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agent_mvc.Service
{
    public class ApiService(IHttpClientFactory clientFactory)
    {
        private static string BaseUrl = "https://localhost:7017/";


        public async Task<List<string>> Index()
        {
            var httpClient = clientFactory.CreateClient();
            var result = await httpClient.GetAsync(BaseUrl + "Calculations/agents");
            var resA = await httpClient.GetAsync(BaseUrl + "Calculations/targets");
            var resB = await httpClient.GetAsync(BaseUrl + "Calculations/missions");
            var resC = await httpClient.GetAsync(BaseUrl + "Calculations/ratio");
            var resD = await httpClient.GetAsync(BaseUrl + "Calculations/optional ratio");
            if (result.IsSuccessStatusCode && resA.IsSuccessStatusCode &&
                resB.IsSuccessStatusCode && resC.IsSuccessStatusCode && 
                resD.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                string? agents = JsonSerializer.Deserialize<string>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                var conA = await result.Content.ReadAsStringAsync();
                string? targets = JsonSerializer.Deserialize<string>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                var conB = await result.Content.ReadAsStringAsync();
                string? missions = JsonSerializer.Deserialize<string>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                var conC = await result.Content.ReadAsStringAsync();
                string? ratio = JsonSerializer.Deserialize<string>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                var conD = await result.Content.ReadAsStringAsync();
                string? optionalRatio = JsonSerializer.Deserialize<string>(content,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                    );
                
                List<string> strings = [agents,targets, missions, ratio, optionalRatio];
                return (strings);
            }
            return new List<string> ();
        }
    }
}
