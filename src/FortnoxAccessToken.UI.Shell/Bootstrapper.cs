using FortnoxAccessToken.UI.Shell.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using FortnoxAccessToken.UI.Module;

namespace FortnoxAccessToken.UI.Shell {
  class Bootstrapper : UnityBootstrapper {
    protected override DependencyObject CreateShell() {
      return Container.Resolve<MainWindow>();
    }

    protected override void InitializeShell() {
      Application.Current.MainWindow.Show();

      //ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
      //moduleCatalog.AddModule(typeof(FortnoxAccessTokenModule));
    }

    protected override void ConfigureModuleCatalog() {
      var moduleCatalog = (ModuleCatalog)ModuleCatalog;
      moduleCatalog.AddModule(typeof(FortnoxAccessTokenModule));
    }
  }
}
