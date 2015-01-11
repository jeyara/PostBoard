using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace TurboDSLR.Framework.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);
    }
}
