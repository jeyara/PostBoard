using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using TurboDSLR.Framework.Caching;
using TurboDSLR.Framework.DependencyManagement;
using TurboDSLR.Framework.Exif;
using TurboDSLR.Framework.ExifReader;
using TurboDSLR.Framework.Web.Page;
using TurboDSLR.Framework.Web.Routing;

namespace TurboDSLR.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("MainCache").SingleInstance();
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
            builder.RegisterType<PageHeadBuilder>().As<IPageHeadBuilder>().InstancePerRequest();
            builder.RegisterType<ExifService>().As<IExifService>().InstancePerRequest();
        }
    }
}
