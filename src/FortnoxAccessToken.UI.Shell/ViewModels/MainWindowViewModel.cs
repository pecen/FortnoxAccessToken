using FortnoxAccessToken.UI.Module.ViewModels;
using FortnoxAccessToken.UI.Shell.Enums;
using FortnoxAccessToken.Utilities.Extensions;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace FortnoxAccessToken.UI.Shell.ViewModels {
  public class MainWindowViewModel : BindableBase {
    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _container;
    public string Title => "Fortnox AccessToken Getter";

    public DelegateCommand<string> NavigateCommand { get; set; }

    private string _contentRegion; // = "ContentRegion";
    public string ContentRegion {
      get { return _contentRegion; }
      set { SetProperty(ref _contentRegion, value); }
    }

    private string _tabRegionRegion; // = "TabRegion";
    public string TabRegion {
      get { return _tabRegionRegion; }
      set { SetProperty(ref _tabRegionRegion, value); }
    }

    public MainWindowViewModel(IRegionManager regionManager, IUnityContainer container) {
      _regionManager = regionManager;
      _container = container;

      NavigateCommand = new DelegateCommand<string>(Navigate);

      ContentRegion = EnumExtensions.GetEnumDescription(WindowRegions.ContentRegion);
      //TabRegion = EnumExtensions.GetEnumDescription(WindowRegions.TabRegion);
      TabRegion = WindowRegions.TabRegion.ToString();
    }

    private void Navigate(string uri) {
      // using Navigation mechanism (not view discovery or view injection
      //_regionManager.RequestNavigate(_contentRegion, uri);
      _regionManager.RequestNavigate(TabRegion, uri);
    }
  }
}
