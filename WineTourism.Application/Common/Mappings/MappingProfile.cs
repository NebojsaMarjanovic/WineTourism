using AutoMapper;
using System.Reflection;

namespace WineTourism.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        //The class assumes a convention where mapping configurations are defined in classes
        //that implement the IMapFrom<> interface and have a method named Mapping
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //This method takes an Assembly parameter, representing the assembly from which to apply mapping configurations.
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // identifies classes in the assembly that implement the IMapFrom<> interface.
            var mapFromType = typeof(IMapFrom<>);

            //For each such class, it looks for a method named Mapping using reflection.
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            //This is a helper method that checks if a given type is an implementation of the IMapFrom<> interface
            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;
            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mappingMethodName); //uzima metodu sa imenom Mapping

                if (methodInfo != null)
                {
                    //poziva metodu Mapping posto postoji
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    //The code proceeds to find interfaces implemented by the type (type.GetInterfaces()).
                    //interfaces is a list containing only those interfaces
                    //that implement the IMapFrom<> interface (as defined by the HasInterface method).
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {
                        //If there are interfaces found (interfaces.Count > 0),
                        //the code iterates through them in a foreach loop.
                        foreach (var @interface in interfaces)
                        {
                            //For each interface, it attempts to get the Mapping method
                            //from the interface (@interface.GetMethod(mappingMethodName, argumentTypes)).
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                            //If the method is found in the interface, it is invoked using the Invoke method on the instance of the type,
                            //and again,the 'this' argument is passed as a parameter to the Mapping method.
                            interfaceMethodInfo.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }

        }
    }
}
