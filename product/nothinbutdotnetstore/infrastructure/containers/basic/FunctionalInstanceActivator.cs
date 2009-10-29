using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class FunctionalInstanceActivator : InstanceActivator
    {
        Func<object> activator;

        public FunctionalInstanceActivator(Func<object> activator)
        {
            this.activator = activator;
        }

        public object create()
        {
            return activator();
        }
    }
}