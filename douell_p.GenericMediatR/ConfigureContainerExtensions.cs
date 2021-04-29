using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Create;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Delete;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Patch;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Save;
using douell_p.GenericMediatR.Handlers.Generics.Commands.Update;
using douell_p.GenericMediatR.Handlers.Generics.Queries.IdQuery;
using douell_p.GenericMediatR.Handlers.Generics.Queries.ListQuery;
using douell_p.GenericRepository;

namespace douell_p.GenericMediatR
{
    public static class ConfigureContainerExtensions
    {
        public static void ConfigureContainer(this ContainerBuilder builder, params Type[] dbContextTypes)
        {
            List<GenericTypesForMediatR> genericTypesForMediatR = IncludedEntities.GetIncludedEntities();

            var handlerGenericsType = new List<TypeInfo>();

            foreach (GenericTypesForMediatR entityType in genericTypesForMediatR)
            {
                if (entityType.QueryById != null)
                    handlerGenericsType.Add((TypeInfo) typeof(IdQueryHandler<,>)
                        .MakeGenericType(entityType.Entity, entityType.QueryById));
                if (entityType.QueryList != null)
                    handlerGenericsType.Add((TypeInfo) typeof(ListQueryHandler<,>)
                        .MakeGenericType(entityType.Entity, entityType.QueryList));
                if (entityType.Create != null)
                    handlerGenericsType.Add((TypeInfo) typeof(CreateCommandHandler<,>)
                        .MakeGenericType(entityType.Entity, entityType.Create));
                if (entityType.Update != null)
                    handlerGenericsType.Add((TypeInfo) typeof(UpdateCommandHandler<,>)
                        .MakeGenericType(entityType.Entity, entityType.Update));
                if (entityType.Patch != null)
                    handlerGenericsType.Add((TypeInfo) typeof(PatchCommandHandler<,>)
                        .MakeGenericType(entityType.Entity, entityType.Patch));
                if (entityType.Delete != null)
                    handlerGenericsType.Add((TypeInfo) typeof(DeleteCommandHandler<,>)
                        .MakeGenericType(entityType.Entity, entityType.Delete));
            }

            var handlerTypes = new List<Type>
            {
                typeof(SaveCommandHandler<>)
            };

            foreach (GenericTypesForMediatR entityType in genericTypesForMediatR)
            foreach (Type handlerType in handlerTypes)
                handlerGenericsType.Add((TypeInfo) handlerType.MakeGenericType(entityType.Entity));

            Type handlerTypeRepository = typeof(Repository<,>);

            foreach (var entityType in genericTypesForMediatR)
            foreach (Type dbContextType in dbContextTypes)
                handlerGenericsType.Add(
                    (TypeInfo) handlerTypeRepository.MakeGenericType(entityType.Entity, dbContextType));

            foreach (TypeInfo handlerGenericType in handlerGenericsType)
            foreach (Type genericType in handlerGenericType.ImplementedInterfaces)
                builder.RegisterType(handlerGenericType).As(genericType);
        }
    }
}