using System;
using System.Collections;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutoWiringInstanceActivator : InstanceActivator
    {
        readonly ConstructorResolver _constructorResolver;
        readonly Type _typeToImplement;

        public AutoWiringInstanceActivator(ConstructorResolver constructor_resolver, Type type_to_implement)
        {
            _constructorResolver = constructor_resolver;
            _typeToImplement = type_to_implement;
        }

        public object create()
        {
            var constructor_info = _constructorResolver.pick_constructor_for(_typeToImplement);
            List<object> param_list = new List<object>();

            constructor_info.GetParameters().each(type => param_list.Add(IOC.resolve.instance_of(type.ParameterType)));
            return Activator.CreateInstance(_typeToImplement, param_list.ToArray());
        }
    }
}