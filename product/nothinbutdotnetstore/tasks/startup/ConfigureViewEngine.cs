using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureViewEngine : StartupCommand
    {
        private readonly ContainerCoreService container_core_service;

        public ConfigureViewEngine(ContainerCoreService container_core_service)
        {
            this.container_core_service = container_core_service;
        }

        public void run()
        {
            container_core_service.register_an_activator_for<ViewPathRegistry>(() => new StubViewPathRegistry());
            container_core_service.register_an_activator_for<ViewFactory>(() => new DefaultViewFactory(container_core_service.resolve<ViewPathRegistry>(),
                BuildManager.CreateInstanceFromVirtualPath));

            container_core_service.register_an_activator_for<ResponseEngine>(() => new DefaultResponseEngine(container_core_service.resolve<ViewFactory>(),
                (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form)));
        }

    }
}