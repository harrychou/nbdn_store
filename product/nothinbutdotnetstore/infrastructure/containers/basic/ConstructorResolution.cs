using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ConstructorResolution    {
        ConstructorInfo pick_constructor_for(Type type);
    }
}