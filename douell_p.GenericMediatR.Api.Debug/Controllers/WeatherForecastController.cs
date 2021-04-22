using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Api.Debug.Entities;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Create;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Delete;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Save;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Update;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.IdQuery;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.ListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace douell_p.GenericMediatR.Api.Debug.Controllers
{
    [ApiController]
    [Route("api/WeatherForecast")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecastsAsync()
        {
            IEnumerable<WeatherForecast> response = await _mediator.Send(new ListQueryModel<WeatherForecast>());

            return Ok(response);
        }

        [HttpGet("{id}", Name = nameof(GetWeatherForecastsByIdAsync))]
        public async Task<IActionResult> GetWeatherForecastsByIdAsync(Guid id)
        {
            WeatherForecast response = await _mediator.Send(new IdQueryModel<WeatherForecast>
            {
                Request = new WeatherForecast {Id = id}
            });

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeatherForecastsAsync([FromBody] WeatherForecast request)
        {
            await _mediator.Send(new CreateCommandModel<WeatherForecast>
            {
                Request = request
            });

            await _mediator.Send(new SaveCommandModel<WeatherForecast>());

            return CreatedAtRoute
                (nameof(GetWeatherForecastsByIdAsync), new {id = request.Id}, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeatherForecastsAsync
            (Guid id, [FromBody] WeatherForecast request)
        {
            WeatherForecast entity = await _mediator.Send(new IdQueryModel<WeatherForecast>
            {
                Request = new WeatherForecast {Id = id}
            });

            if (entity == null)
                return NotFound();

            entity.Name = request.Name;

            await _mediator.Send(new UpdateCommandModel<WeatherForecast>
            {
                Request = entity
            });

            await _mediator.Send(new SaveCommandModel<WeatherForecast>());

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationTemplatesAsync(Guid id)
        {
            WeatherForecast entity = await _mediator.Send(new IdQueryModel<WeatherForecast>
            {
                Request = new WeatherForecast {Id = id}
            });

            if (entity == null)
                return NotFound();

            await _mediator.Send(new DeleteCommandModel<WeatherForecast>
            {
                Request = entity
            });
            
            await _mediator.Send(new SaveCommandModel<WeatherForecast>());

            return NoContent();
        }
    }
}