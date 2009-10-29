using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface ContainerCoreService
    {
        void register_an_activator_for<ContractType>(Func<object> activator);
        Dependency resolve<Dependency>();
    }
}