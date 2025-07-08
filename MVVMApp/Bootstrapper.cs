using System;

using Autofac;

using MVVMApp.Configuration;
using MVVMApp.LoggingService;
using MVVMApp.Model;
using MVVMApp.Services;
using MVVMApp.View;
using MVVMApp.ViewModel;
using MVVMApp.ViewModel.Custom;

namespace MVVMApp
{
    internal static class Bootstrapper
    {
        #region Constants

        private const string APP_DOMAIN_NAME = "MVVMApp";

        #endregion Constants

        #region Fields

        private static IContainer _container;

        #endregion Fields

        #region Public Methods

        public static void Run(CustomizationSettings customization)
        {
            // Build a new Autofac container.
            var builder = new ContainerBuilder();

            AppDomain.CurrentDomain.Load($"{APP_DOMAIN_NAME}.View.{customization.View}");
            AppDomain.CurrentDomain.Load($"{APP_DOMAIN_NAME}.Model.{customization.Model}");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                   .As<IMainWindow>()
                   .SingleInstance();

            builder.RegisterType<MainWindowViewModel>()
                   .As<IViewModel>()
                   .SingleInstance();

            builder.RegisterAssemblyTypes(assemblies)
                   .As<IModel>()
                   .SingleInstance();

            builder.RegisterType<LogService>()
                   .As<ILogService>()
                   .SingleInstance();

            _container = builder.Build();
        }

        public static T? Resolve<T>()
        {
            if (_container == null)
                return default;

            if (!_container.IsRegistered<T>())
                return default;

            return _container.Resolve<T>();
        }

        #endregion Public Methods
    }
}