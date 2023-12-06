using Capstone.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace MyMvcApp.DAL
{
    public class GymPopulationDbContext : DbContext 
    {
        public GymPopulationDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<GymPopulation> GymPopulations {get; set;}
    }
}