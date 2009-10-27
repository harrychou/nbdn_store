using System.IO;
using System.Web;

namespace nothinbutdotnetstore.tests.utility
{
    public class ObjectMother
    {
        static public HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static public HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        static protected HttpRequest create_request()
        {
            return new HttpRequest("blah.aspx", "http://local/blah.aspx", string.Empty);
        }
    }
}