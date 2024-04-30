using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers;

public class FitnessPlanController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;

    public FitnessPlanController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetFitnessPlan(int time, string equipment, string muscle, string fitness_level, string fitness_goals)
    {
        var client = _clientFactory.CreateClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://workout-planner1.p.rapidapi.com/customized?time="+ time +"&equipment="+ equipment +"&muscle="+ muscle +"&fitness_level="+ fitness_level +"&fitness_goals="+ fitness_goals +""),
            Headers =
            {
                { "X-RapidAPI-Key", _configuration["RapidAPI:Key"] },
                { "X-RapidAPI-Host", _configuration["RapidAPI:Host"] },
            },
        };

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var plan = await response.Content.ReadAsStringAsync();
            var fitnessPlan = new FitnessPlanViewModel { Plan = plan };
            Console.WriteLine(fitnessPlan);
            return Ok(fitnessPlan);
        }
    }
}


