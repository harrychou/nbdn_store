using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ImplementationRegistry {
        Type get_implementation_of(Type type);
    }
}