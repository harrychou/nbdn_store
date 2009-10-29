using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface InstanceActivator
    {
        object create();
    }

    public class DefaultInstanceActivator : InstanceActivator 
    {
        private readonly Func<object> activator;

        public DefaultInstanceActivator(Func<object> activator)
        {
            this.activator = activator;
        }
        public object create()
        {
            return activator();
        }
    }

}