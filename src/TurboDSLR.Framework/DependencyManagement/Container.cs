using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using TurboDSLR.Framework.Reflection;

namespace TurboDSLR.Framework.DependencyManagement
{
    public class Container
    {
        private static ContainerBuilder _cb;
        private static IContainer _container;
        private static bool _autoRegistered = false;

        private Container()
        {
        }

        public static ContainerBuilder CurrentBuilder
        {
            get
            {
                if (_cb == null)
                {
                    _cb = new ContainerBuilder();
                    DoAutoRegister();
                }

                return _cb;
            }
        }

        public static void DoAutoRegister(bool force = false)
        {
            if (!_autoRegistered || force)
            {
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
                    dependencyRegistrar.Register(CurrentBuilder);

                #endregion

                CurrentBuilder.RegisterModule<AutofacWebTypesModule>();

                _autoRegistered = true;
            }
        }

        public static System.Web.Mvc.IDependencyResolver GetMVCResolver()
        {
            if (_container == null)
                _container = _cb.Build();

            var mvcResolver = new AutofacDependencyResolver(_container);

            return (IDependencyResolver)mvcResolver;
        }

        public static System.Web.Http.Dependencies.IDependencyResolver GetAPIResolver()
        {
            if (_container == null)
                _container = _cb.Build();

            var webApiResolver = new AutofacWebApiDependencyResolver(_container);

            return (System.Web.Http.Dependencies.IDependencyResolver)webApiResolver;
        }

        public static T Resolve<T>() where T : class
        {
            if (_container == null)
                _container = _cb.Build();

            return _container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            if (_container == null)
                _cb.Build();

            return _container.Resolve(type);
        }

        //T[] ResolveAll<T>();
    }

}
