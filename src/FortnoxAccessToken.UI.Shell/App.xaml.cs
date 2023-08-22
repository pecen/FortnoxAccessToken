using FortnoxAccessToken.UI.Module;
using FortnoxAccessToken.UI.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace FortnoxAccessToken.UI.Shell
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			base.ConfigureModuleCatalog(moduleCatalog);

			moduleCatalog.AddModule(typeof(FortnoxAccessTokenModule));
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			base.RegisterRequiredTypes(containerRegistry);
		}
	}
}
