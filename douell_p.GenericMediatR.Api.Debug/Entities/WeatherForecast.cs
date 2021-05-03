using System;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.CreateWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.DeleteWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.PatchWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.UpdateWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Queries.GetWeatherForecastById;
using pdouelle.Entity;

namespace douell_p.GenericMediatR.Api.Debug.Entities
{
    [
        GenericMediatREntity
        (
            QueryById = typeof(GetWeatherForecastByIdQueryModel),
            Create = typeof(CreateWeatherForecastCommandModel),
            Update = typeof(UpdateWeatherForecastCommandModel),
            Patch = typeof(PatchWeatherForecastCommandModel),
            Delete = typeof(DeleteWeatherForecastCommandModel)
        )
    ]
    public class WeatherForecast : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}