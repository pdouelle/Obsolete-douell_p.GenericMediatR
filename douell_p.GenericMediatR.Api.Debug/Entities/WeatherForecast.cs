using System;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.CreateWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.DeleteWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.UpdateWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Queries.GetWeatherForecastById;
using douell_p.GenericRepository;

namespace douell_p.GenericMediatR.Api.Debug.Entities
{
    [
        MediatREntity
        (
            QueryById = typeof(GetWeatherForecastByIdQueryModel),
            Create = typeof(CreateWeatherForecastCommandModel),
            Update = typeof(UpdateWeatherForecastCommandModel),
            Delete = typeof(DeleteWeatherForecastCommandModel)
        )
    ]
    public class WeatherForecast : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}