using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TurboDSLR.Framework.Caching;
using TurboDSLR.Framework.DependencyManagement;
using TurboDSLR.Framework.Web.Routing;

namespace TurboDSLR.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("MainCache").SingleInstance();
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }
    }
}
