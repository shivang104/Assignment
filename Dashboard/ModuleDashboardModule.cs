
using Dashboard;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Assignment.Infrastructure;
namespace DashboardModule 
{
    public class ModuleDashboardModule : ModuleBase
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ModuleDashboardModule(RegionManager regionManager, IUnityContainer container) : base(container, regionManager)
        {
            _regionManager = regionManager;
            _container = container;
        }

        protected override void InitializeModule()
        {
            
        }
        protected override void RegisterTypes()
        {
            Container.RegisterType<IDashboardVM, DashboardVM>();
            Container.RegisterTypeForNavigation<DashboardView>();
        }
       
    }
}
