using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Create;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Delete;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Save;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Update;
using douell_p.GenericMediatR.Handlers.Generics.Queries.IdQuery;
using douell_p.GenericMediatR.Handlers.Generics.Queries.ListQuery;
using douell_p.GenericRepository;

namespace douell_p.GenericMediatR
{
    public static class ConfigureContainerExtensions
    {
        public static void ConfigureContainer
        (this ContainerBuilder builder, Type[] entityTypes, Type[] dbContextTypes,
            Tuple<Type, Type>[] excludesGenericMediatR = null)
        {
            var handlerTypes = new List<Type>
            {
                typeof(IdQueryHandler<>),
                typeof(ListQueryHandler<>),
                typeof(CreateCommandHandler<>),
                typeof(UpdateCommandHandler<>),
                typeof(DeleteCommandHandler<>),
                typeof(SaveCommandHandler<>)
            };

            foreach (Type entityType in entityTypes)
            foreach (Type handlerType in handlerTypes)
            {
                if (excludesGenericMediatR?.Any(x => x.Item1 == handlerType & x.Item2 == entityType) == true)
                    continue;

                var handlerGenericType = (TypeInfo) handlerType.MakeGenericType(entityType);
                foreach (Type genericType in handlerGenericType.ImplementedInterfaces)
                    builder.RegisterType(handlerGenericType).As(genericType);
            }

            Type handlerTypeRepository = typeof(Repository<,>);

            foreach (Type entityType in entityTypes)
            foreach (Type dbContextType in dbContextTypes)
            {
                var handlerGenericType =
                    (TypeInfo) handlerTypeRepository.MakeGenericType(entityType, dbContextType);

                foreach (Type genericType in handlerGenericType.ImplementedInterfaces)
                    builder.RegisterType(handlerGenericType).As(genericType);
            }
        }
    }
}