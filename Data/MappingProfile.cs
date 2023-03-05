using AutoMapper;
using stankin1.Interfaces;
using System.Reflection;

namespace stankin1.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadCustomMappings(Assembly.GetExecutingAssembly());
        }

        private void LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                from type in types
                from instance in type.GetInterfaces()
                where
                    typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                    !type.IsAbstract &&
                    !type.IsInterface &&
                    !type.ContainsGenericParameters
                select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();
            mapsFrom.AddRange(
                from type in types
                from instance in type.GetInterfaces()
                where
                    typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                    !type.IsAbstract &&
                    !type.IsInterface &&
                    type.ContainsGenericParameters
                select (IHaveCustomMapping)Activator.CreateInstance(type.MakeGenericType(typeof(object))));
            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
