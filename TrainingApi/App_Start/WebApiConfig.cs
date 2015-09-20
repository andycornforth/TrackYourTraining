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

            //Muscle 
            config.Routes.MapHttpRoute(
                name: "MusclesRoute",
                routeTemplate: "api/Muscle",
                defaults: new { controller = "Muscle" }
            );

            config.Routes.MapHttpRoute(
                name: "MuscleByIdRoute",
                routeTemplate: "api/Muscle/{id}",
                defaults: new { controller = "Muscle" }
            );

            //Movement
            config.Routes.MapHttpRoute(
                name: "MovementsRoute",
                routeTemplate: "api/Movement",
                defaults: new { controller = "Movement" }
            );

            config.Routes.MapHttpRoute(
                name: "MovementByIdRoute",
                routeTemplate: "api/Movement/{id}",
                defaults: new { controller = "Movement" }
            );

            config.Routes.MapHttpRoute(
                name: "MovementAddRoute",
                routeTemplate: "api/Movement",
                defaults: new { controller = "Movement" }
            );

            //Set
            config.Routes.MapHttpRoute(
                name: "SetByIdRoute",
                routeTemplate: "api/Set/{id}",
                defaults: new { controller = "Set"}
            );

            config.Routes.MapHttpRoute(
                name: "SetAddRoute",
                routeTemplate: "api/Set",
                defaults: new { controller = "Set", action = "Post" }//not working
            );

            //Day
            config.Routes.MapHttpRoute(
                name: "DayByIdRoute",
                routeTemplate: "api/DayName/{dayId}",
                defaults: new { controller = "Day", action = "GetDayName" }
            );

            config.Routes.MapHttpRoute(
                name: "SetsByDayIdRoute",
                routeTemplate: "api/SetsForDay/{dayId}",
                defaults: new { controller = "Day", action = "GetSetsForDay" }
            );

            config.Routes.MapHttpRoute(
                name: "DayAddRoute",
                routeTemplate: "api/AddDay/",
                defaults: new { controller = "Day", action = "PostNewDay" }//not working
            );

            //Program
            config.Routes.MapHttpRoute(
                name: "ProgramsRoute",
                routeTemplate: "api/Programs",
                defaults: new { controller = "Program", action = "GetAllPrograms" }
            );

            config.Routes.MapHttpRoute(
                name: "ProgramByIdRoute",
                routeTemplate: "api/Program/{programId}",
                defaults: new { controller = "Program", action = "GetProgram" }
            );

            config.Routes.MapHttpRoute(
                name: "DaysbyProgramIdRoute",
                routeTemplate: "api/Days/{programId}",
                defaults: new { controller = "Program", action = "GetDaysForProgram" }
            );

            config.Routes.MapHttpRoute(
                name: "ProgramAddRoute",
                routeTemplate: "api/Program",
                defaults: new { controller = "Program", action = "PostNewProgram" },
                constraints: new { controller = "Program", action = "PostNewProgram" }
            );
        }
    }
}
