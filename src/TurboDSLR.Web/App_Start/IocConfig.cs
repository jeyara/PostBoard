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
            var builder = new ContainerBuilder();

            #region Dynamic Discovery of Services and Classes using AutoFac

            /*
             * Code will look for IDependencyRegistrar interface in all loaded assemblies.
             * It will skip all the assemblies such as EF, MiniProfiler etc. Only looks in assembly belongs to this solution.
             * This decouples the worry of registering Services here. All you need to add the service in the class which
             * implements IDependencyRegistrar interface in their respective Project. System will iterate it to load.
             */

            var typeFinder = new TypeFinder();
            var drInstances = typeFinder.FindClassInstancesOfType<IDependencyRegistrar>();

            //sort
            //drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();

            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder);

            #endregion


            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();


            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

    }
}