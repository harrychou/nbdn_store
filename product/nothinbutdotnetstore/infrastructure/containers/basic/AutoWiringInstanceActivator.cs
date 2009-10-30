using System;
using System.Linq;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutoWiringInstanceActivator : InstanceActivator
    {
        ConstructorResolution constructor_resolution;
        Type type_to_implement;

        public AutoWiringInstanceActivator(ConstructorResolution constructor_resolution, Type type_to_implement)
        {
            this.constructor_resolution = constructor_resolution;
            this.type_to_implement = type_to_implement;
        }

        public object create()
        {
            var constructor_info = constructor_resolution.pick_constructor_for(type_to_implement);

            var parameters = constructor_info.GetParameters()
                .Select(info => IOC.resolve.instance_of(info.ParameterType));

            return Activator.CreateInstance(type_to_implement, parameters.ToArray());
        }
    }
}