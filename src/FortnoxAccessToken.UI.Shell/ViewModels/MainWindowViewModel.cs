using FortnoxAccessToken.UI.Module.ViewModels;
using FortnoxAccessToken.Core.Extensions;
using FortnoxAccessToken.Core.Enums.UI;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace FortnoxAccessToken.UI.Shell.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		public string Title => "Fortnox AccessToken Getter";

		public DelegateCommand<string> NavigateCommand { get; set; }

		private string _contentRegion; // = "ContentRegion";
		public string ContentRegion
		{
			get { return _contentRegion; }
			set { SetProperty(ref _contentRegion, value); }
		}

		private string _tabRegionRegion; // = "TabRegion";
		public string TabRegion
		{
			get { return _tabRegionRegion; }
			set { SetProperty(ref _tabRegionRegion, value); }
		}

		public MainWindowViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;

			NavigateCommand = new DelegateCommand<string>(Navigate);

			ContentRegion = RegionNames.ContentRegion.ToString(); // WindowRegions.ContentRegion.GetEnumDescription();
			TabRegion = RegionNames.TabRegion.ToString(); // TabRegion = WindowRegions.TabRegion.GetEnumDescription();
		}

		private void Navigate(string uri)
		{
			// using Navigation mechanism (not view discovery or view injection)
			//_regionManager.RequestNavigate(_contentRegion, uri);
			_regionManager.RequestNavigate(TabRegion, uri);
		}
	}
}
