using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Macronix_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "CreatePerson",
            url: "PeopleForm/Create",
            defaults: new { controller = "PeopleForm", action = "Create" }
            );


            routes.MapRoute(
    name: "DeletePerson",
    url: "PeopleoForm/Delete",
    defaults: new { controller = "PeopleoForm", action = "Delete" }
);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PeopleoForm", action = "Index", id = UrlParameter.Optional }
            );


        }

    }
}
