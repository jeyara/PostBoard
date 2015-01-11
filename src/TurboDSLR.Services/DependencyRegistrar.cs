using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TurboDSLR.Framework.DependencyManagement;
using TurboDSLR.Services.Core;

namespace TurboDSLR.Services
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<SettingService>().As<ISettingService>();
            builder.RegisterType<ImageService>().As<IImageService>();
        }
    }
}
