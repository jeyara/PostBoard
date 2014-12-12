using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PostBoard.Framework.DependencyManagement;
using PostBoard.Services.Core;

namespace PostBoard.Services
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
