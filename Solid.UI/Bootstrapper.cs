using Caliburn.Micro;
using Flurl.Http.Configuration;
using Solid.UI.API;
using Solid.UI.API.Implementation;
using Solid.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Solid.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        public SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IFlurlClientFactory, DefaultFlurlClientFactory>();
            _container.Singleton<IPackageService, PackageService>();

            _container.PerRequest<ShellViewModel>();
        }

        protected override void OnStartup(object obj, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewForAsync<ShellViewModel>();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { Assembly.GetExecutingAssembly() };
        }

    }
}
