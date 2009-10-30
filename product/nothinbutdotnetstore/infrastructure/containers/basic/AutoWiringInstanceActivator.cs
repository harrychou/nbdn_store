using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class AutoWiringInstanceActivator : InstanceActivator
    {
        readonly ConstructorResolver _constructorResolver;

        public AutoWiringInstanceActivator(ConstructorResolver constructor_resolver)
        {
            _constructorResolver = constructor_resolver;
        }

        public object create()
        {
            throw new NotImplementedException();
        }
    }
}