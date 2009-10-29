using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureViewEngine : StartupCommand
    {
        ContainerCoreService core_services;

        public ConfigureViewEngine(ContainerCoreService core_services)
        {
            this.core_services = core_services;
        }

        public void run()
        {
            core_services.register_an_activator_for<ViewPathRegistry>(() => new StubViewPathRegistry());
            core_services.register_an_activator_for<ViewFactory>(() => new DefaultViewFactory(core_services.resolve<ViewPathRegistry>(),
                BuildManager.CreateInstanceFromVirtualPath));

            core_services.register_an_activator_for<ResponseEngine>(() => new DefaultResponseEngine(core_services.resolve<ViewFactory>(),
                (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form)));
        }

    }
}