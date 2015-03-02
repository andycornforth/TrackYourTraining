using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TrainingApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MusclesRoute",
                routeTemplate: "api/Muscle/",
                defaults: new { controller = "Muscle" }
            );

            config.Routes.MapHttpRoute(
                name: "MuscleByIdRoute",
                routeTemplate: "api/Muscle/{id}",
                defaults: new { controller = "Muscle" }
            );

            config.Routes.MapHttpRoute(
                name: "MovementsRoute",
                routeTemplate: "api/Movement/",
                defaults: new { controller = "Movement" }
            );

            config.Routes.MapHttpRoute(
                name: "MovementByIdRoute",
                routeTemplate: "api/Movement/{id}",
                defaults: new { controller = "Movement" }
            );

            config.Routes.MapHttpRoute(
                name: "MovementAdd",
                routeTemplate: "api/Movement/",
                defaults: new { controller = "Movement" }
            );
        }
    }
}
