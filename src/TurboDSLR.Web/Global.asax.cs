﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using StackExchange.Profiling;

namespace TurboDSLR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IocConfig.RegisterIoc();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.EnsureInitialized(); 
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
