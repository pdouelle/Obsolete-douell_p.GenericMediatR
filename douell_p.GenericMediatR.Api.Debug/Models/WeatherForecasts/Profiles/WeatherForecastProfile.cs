using AutoMapper;
using douell_p.GenericMediatR.Api.Debug.Entities;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.CreateWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.PatchWeatherForecast;
using douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Models.Commands.UpdateWeatherForecast;

namespace douell_p.GenericMediatR.Api.Debug.Models.WeatherForecasts.Profiles
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<CreateWeatherForecastCommandModel, WeatherForecast>();
            CreateMap<UpdateWeatherForecastCommandModel, WeatherForecast>();
            CreateMap<PatchWeatherForecastCommandModel, WeatherForecast>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}