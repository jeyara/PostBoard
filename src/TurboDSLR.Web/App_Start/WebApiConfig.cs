﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TurboDSLR
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            // Web API routes
            configuration.MapHttpAttributeRoutes();

            //configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
            //    new { id = RouteParameter.Optional });
        }
    }
}