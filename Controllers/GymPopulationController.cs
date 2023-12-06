using System.Diagnostics;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyMvcApp.DAL;

namespace Capstone.Controllers
{
    public class GymPopulationController : Controller
    {
        private readonly GymPopulationDbContext _context;
        public GymPopulationController(GymPopulationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var gymPopulations = _context.GymPopulations.ToList();
            List<GymPopulationViewModel> gymPopulationsList = new List<GymPopulationViewModel>();

            if (gymPopulations != null)
            {
                foreach (var entry in gymPopulations)
                {
                    var GymPopulationViewModel = new GymPopulationViewModel()
                    {
                        Monday = entry.Monday,
                        Tuesday = entry.Tuesday,
                        Wednesday = entry.Wednesday,
                        Thursday = entry.Thursday,
                        Friday = entry.Friday,
                        Saturday = entry.Saturday,
                        Sunday = entry.Sunday
                    };
                    gymPopulationsList.Add(GymPopulationViewModel);
                }
                return View(gymPopulationsList);
            }
            return View(gymPopulationsList);
        }

        public IActionResult Dashboard()
        {
            var gymPopulations = _context.GymPopulations.ToList();
            List<GymPopulationViewModel> gymPopulationsList = new List<GymPopulationViewModel>();

            if (gymPopulations != null)
            {
                foreach (var entry in gymPopulations)
                {
                    var gymPopulationViewModel = new GymPopulationViewModel()
                    {
                        Monday = entry.Monday,
                        Tuesday = entry.Tuesday,
                        Wednesday = entry.Wednesday,
                        Thursday = entry.Thursday,
                        Friday = entry.Friday,
                        Saturday = entry.Saturday,
                        Sunday = entry.Sunday
                    };
                    gymPopulationsList.Add(gymPopulationViewModel);
                }

                return View("Index", gymPopulationsList);
            }

            return View("Index", gymPopulationsList);
        }
    }
}