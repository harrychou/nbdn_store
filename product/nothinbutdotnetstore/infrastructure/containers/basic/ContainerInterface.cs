using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ContainerInterface
    {
        T instance_of<T>();
        object instance_of(Type item);
    }

    public class DefaultContainer : ContainerInterface
    {
        public T instance_of<T>()
        {
            return (T)instance_of(typeof (T));
        }

        public object instance_of(Type item)
        {
            return Activator.CreateInstance(item);
        }
    }
}