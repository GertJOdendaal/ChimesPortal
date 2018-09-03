using System.Web.Http;

namespace ChimesPortal.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code
            var corsAttr = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}