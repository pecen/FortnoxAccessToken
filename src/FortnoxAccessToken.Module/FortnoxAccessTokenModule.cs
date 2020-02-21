using FortnoxAccessToken.Module.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace FortnoxAccessToken.Module {
  public class FortnoxAccessTokenModule : IModule {
    private IRegionManager _regionManager;
    private IUnityContainer _container;

    public FortnoxAccessTokenModule(IUnityContainer container, IRegionManager regionManager) {
      _container = container;
      _regionManager = regionManager;
    }

    public void Initialize() {
      _regionManager.RegisterViewWithRegion("ContentRegion", typeof(GetAccessToken));

      _container.RegisterTypeForNavigation<GetAccessToken>();
    }
  }
}