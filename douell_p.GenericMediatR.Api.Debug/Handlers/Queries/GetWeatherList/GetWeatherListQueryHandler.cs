using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Api.Debug.Entities;
using douell_p.GenericMediatR.Handlers.Generics.Queries.ListQuery;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.ListQuery;
using douell_p.GenericRepository;

namespace douell_p.GenericMediatR.Api.Debug.Handlers.Queries.GetWeatherList
{
    public class GetWeatherListQueryHandler : ListQueryHandler<WeatherForecast>
    {
        public GetWeatherListQueryHandler(IRepository<WeatherForecast> repository) : base(repository)
        {
        }
        
        public override async Task<IEnumerable<WeatherForecast>> Handle(ListQueryModel<WeatherForecast> listQuery, CancellationToken cancellationToken)
        {
            Console.WriteLine("coucou");
            return await base.Handle(listQuery, cancellationToken);
        }
    }
}