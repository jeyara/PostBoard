using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PostBoard.Framework.DependencyManagement;
using PostBoard.Framework.Web.Routing;

namespace PostBoard
{
    public class IocConfig
    {
        public static void RegisterIoc()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            IDependencyRegistrar framework = new PostBoard.Framework.DependencyRegistrar();
            framework.Register(builder);

            IDependencyRegistrar da = new PostBoard.Data.DependencyRegistrar();
            da.Register(builder);

            IDependencyRegistrar svc = new PostBoard.Services.DependencyRegistrar();
            svc.Register(builder);
            
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}