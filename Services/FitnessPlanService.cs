using System;
using System.Net.Http;
using System.Threading.Tasks;

public class FitnessPlanService
{
    private readonly HttpClient _httpClient;

    public FitnessPlanService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetFitnessPlanAsync(int age, string gender, string activityLevel)
    {
        var requestUri = $"https://workout-planner1.p.rapidapi.com/customized?time=30&equipment=dumbbells&muscle=biceps&fitness_level={activityLevel}&fitness_goals=strength";
        
        var response = await _httpClient.GetAsync(requestUri);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
