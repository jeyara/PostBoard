using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PostBoard.Data.Repository;
using PostBoard.Framework.DependencyManagement;

namespace PostBoard.Data
{
    public class DependencyRegistrar: IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.Register<IDbContext>(c => new DAObjectContext(ConfigurationManager.ConnectionStrings["Local"].ConnectionString)).SingleInstance();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));
        }

    }
}
