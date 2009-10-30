using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ConstructorResolver    {
        ConstructorInfo pick_constructor_for(Type type);
    }
}