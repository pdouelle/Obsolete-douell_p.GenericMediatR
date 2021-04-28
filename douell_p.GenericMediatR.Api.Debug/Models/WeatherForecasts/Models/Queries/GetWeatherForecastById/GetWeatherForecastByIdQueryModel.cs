using System;
using douell_p.GenericRepository;

namespace douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Queries.GetWeatherForecastById
{
    public class GetWeatherForecastByIdQueryModel : IEntity
    {
        public Guid Id { get; set; }
    }
}