using douell_p.GenericMediatR.Api.Debug.Entities;
using Microsoft.EntityFrameworkCore;

namespace douell_p.GenericMediatR.Api.Debug.Data
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}