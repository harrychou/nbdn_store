using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ContainerInterface
    {
        T instance_of<T>();
        object instance_of(Type item);
    }

    public class DefaultContainer: ContainerInterface  {
        public DefaultContainer() {}

        public T instance_of<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public object instance_of(Type item)
        {
            return Activator.CreateInstance(item);
        }
    }
}