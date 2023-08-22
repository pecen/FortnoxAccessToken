using FortnoxAccessToken.Core.Enums.UI;
using FortnoxAccessToken.UI.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace FortnoxAccessToken.UI.Module
{
	public class FortnoxAccessTokenModule : IModule
	{
		private readonly IRegionManager _regionManager;

		public FortnoxAccessTokenModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void Initialize()
		{
			// Old code. Probably can be removed. 

			//_regionManager.RegisterViewWithRegion("ContentRegion", typeof(GetAccessToken));
			//_regionManager.RegisterViewWithRegion("ContentRegion", typeof(AppConfig));

			//_regionManager.RegisterViewWithRegion("TabRegion", typeof(GetAccessToken));
			//_regionManager.RegisterViewWithRegion("TabRegion", typeof(AppConfig));

			//_container.RegisterTypeForNavigation<GetAccessToken>("GetAccessToken");
			//_container.RegisterTypeForNavigation<AppConfig>("AppConfig");
		}

		public void OnInitialized(IContainerProvider containerProvider)
		{
			// Prism's navigation mechanism
			_regionManager.RequestNavigate(RegionNames.TabRegion.ToString(), nameof(GetAccessToken));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<GetAccessToken>("GetAccessToken");
			containerRegistry.RegisterForNavigation<AppConfig>("AppConfig");
		}
	}
}