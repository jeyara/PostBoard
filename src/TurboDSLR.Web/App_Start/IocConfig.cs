using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using TurboDSLR.Framework.DependencyManagement;
using TurboDSLR.Framework.Reflection;
using TurboDSLR.Framework.Web.Routing;

namespace TurboDSLR
{
    public class IocConfig
    {
        public static void RegisterIoc()
        {
            var builder = Container.CurrentBuilder;

            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            GlobalConfiguration.Configuration.DependencyResolver = Container.GetAPIResolver();
            DependencyResolver.SetResolver(Container.GetMVCResolver());
        }

    }
}