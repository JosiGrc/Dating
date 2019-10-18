using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Dating.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GeocodeApi",
                routeTemplate: "api/{People}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}