using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace douell_p.GenericMediatR
{
    public static class IncludedEntities
    {
        public static Assembly[] Assemblies { get; set; }

        public static List<GenericTypesForMediatR> GetIncludedEntities()
        {
            var typeList = new List<GenericTypesForMediatR>();

            foreach (Assembly assembly in Assemblies)
            {
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    var customAttribute = (MediatREntityAttribute) type
                        .GetCustomAttributes(typeof(MediatREntityAttribute))
                        .FirstOrDefault();

                    if (customAttribute != null)
                    {
                        typeList.Add(new GenericTypesForMediatR
                        {
                            Entity = type,
                            QueryList = customAttribute.QueryList,
                            QueryById = customAttribute.QueryById,
                            Create = customAttribute.Create,
                            Update = customAttribute.Update,
                            Patch = customAttribute.Patch,
                            Delete = customAttribute.Delete
                        });
                    }
                }
            }

            return typeList;
        }
    }
}