using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers;

public class FitnessPlanController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public FitnessPlanController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
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
                { "X-RapidAPI-Key", "7091effc2emshfa536272507b037p129d0djsn67dea0cf8dea" },
                { "X-RapidAPI-Host", "workout-planner1.p.rapidapi.com" },
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

