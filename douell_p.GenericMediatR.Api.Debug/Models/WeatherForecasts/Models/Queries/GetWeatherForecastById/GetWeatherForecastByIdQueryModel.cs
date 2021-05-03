using System;
using pdouelle.Entity;

namespace douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Queries.GetWeatherForecastById
{
    public class GetWeatherForecastByIdQueryModel : IEntity
    {
        public Guid Id { get; set; }
    }
}