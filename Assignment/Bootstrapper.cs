using LoginModule;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Windows;
using DashboardModule;

namespace Assignment
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShellVM, ShellVM>();
        }
        //protected override void ConfigureModuleCatalog()
        //{
        //    Type LoginModuleType = typeof(ModuleLoginModule);
        //    ModuleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = LoginModuleType.Name,
        //        ModuleType = LoginModuleType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.WhenAvailable
        //    });
        //    Type DashboardModuleType = typeof(ModuleDashboardModule);
        //    ModuleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = DashboardModuleType.Name,
        //        ModuleType = DashboardModuleType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.WhenAvailable
        //    });
        //}


        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ModuleLoginModule));
            catalog.AddModule(typeof(ModuleDashboardModule));

            return catalog;
        }
    }
}
