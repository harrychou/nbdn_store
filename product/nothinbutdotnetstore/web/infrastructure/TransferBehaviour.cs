using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public delegate void TransferBehaviour(IHttpHandler handler, bool preserve_form);
}