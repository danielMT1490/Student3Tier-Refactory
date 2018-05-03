using Student.Business.Facade.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Student.Business.Facade
{
    public static class WebApiConfig
    {
        
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            //versionado de apis
            config.Routes.MapHttpRoute(
                name: "Version1Api",//Nombre de la version
                routeTemplate: "api/v1/{controller}/{action}/{id}",//ruta
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "Version2Api",
              routeTemplate: "api/v2/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector((config)));
        }
    }
}
