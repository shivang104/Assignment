using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Assignment.Infrastructure;



namespace LoginModule
{
    public class ModuleLoginModule : ModuleBase
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ModuleLoginModule(RegionManager regionManager, IUnityContainer container) : base(container, regionManager)
        {
            _regionManager = regionManager;
            _container = container;
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion("ContentRegion", typeof(LoginView));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<ILoginVM, LoginVM>();
            Container.RegisterTypeForNavigation<LoginView>();
            Container.RegisterType<IRegisterVM, RegisterVM>();
            Container.RegisterTypeForNavigation<RegisterView>();
        }
    }
}
