using System;
using douell_p.GenericRepository;

namespace douell_p.GenericMediatR.Api.Debug.Entities
{
    public class WeatherForecast : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}