using System;
using System.Collections.Generic;
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
            (this ContainerBuilder builder, Type[] entityTypes, Type[] dbContextTypes)
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