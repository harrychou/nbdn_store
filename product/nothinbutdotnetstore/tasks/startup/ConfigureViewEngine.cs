using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.web.infrastructure;

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
            TransferBehaviour transfer = (handler, preserve_form) => HttpContext.Current.Server.Transfer(handler, preserve_form);
            PageFactory page_factory = BuildManager.CreateInstanceFromVirtualPath;
            core_services.register_an_activator_for<PageFactory>(() => page_factory);
            core_services.register_an_activator_for<TransferBehaviour>(() => transfer);
        }
    }
}