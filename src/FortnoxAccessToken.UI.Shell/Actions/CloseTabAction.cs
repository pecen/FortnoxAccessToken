using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace FortnoxAccessToken.UI.Shell.Actions
{
	public class CloseTabAction : BaseTabAction // TriggerAction<Button>
	{
		protected override void Invoke(object parameter)
		{
			var args = parameter as RoutedEventArgs;

			if (args == null)
			{
				return;
			}

			var tabItem = FindParent<TabItem>(args.OriginalSource as DependencyObject);
			if (tabItem == null)
			{
				return;
			}

			var tabControl = FindParent<TabControl>(tabItem);
			if (tabControl == null)
			{
				return;
			}

			IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
			if (region == null)
			{
				return;
			}

			// By using the following commented out code, we're not checking if the tab
			// could be removed or not. 
			//if (region.Views.Contains(tabItem.Content)) {
			//  region.Remove(tabItem.Content);
			//}

			// The following code/methods checks if our views implement the IConfirmNavigationRequest,
			// and thus checks if the tab could be removed or not. 
			RemoveItemFromRegion(tabItem.Content, region);
		}

		void RemoveItemFromRegion(object item, IRegion region)
		{
			var navigationContext = new NavigationContext(region.NavigationService, null);

			if (CanRemove(item, navigationContext))
			{
				InvokeOnNavigatedFrom(item, navigationContext);
				region.Remove(item);
			}
		}

		void InvokeOnNavigatedFrom(object item, NavigationContext navigationContext)
		{
			if (item is INavigationAware navigationAwareItem)
			{
				navigationAwareItem.OnNavigatedFrom(navigationContext);
			}

			if (item is FrameworkElement frameworkElement)
			{
				if (frameworkElement.DataContext is INavigationAware navigationAwareDataContext)
				{
					navigationAwareDataContext.OnNavigatedFrom(navigationContext);
				}
			}
		}

		bool CanRemove(object item, NavigationContext navigationContext)
		{
			bool canRemove = true;

			if (item is IConfirmNavigationRequest confirmRequestItem)
			{
				confirmRequestItem.ConfirmNavigationRequest(navigationContext, result =>
				{
					canRemove = result;
				});
			}

			if (item is FrameworkElement frameworkElement && canRemove)
			{
				if (frameworkElement.DataContext is IConfirmNavigationRequest confirmRequestDataContest)
				{
					confirmRequestDataContest.ConfirmNavigationRequest(navigationContext, result =>
					{
						canRemove = result;
					});
				}
			}

			return canRemove;
		}

		//Moved this to BaseTabAction

		//static T FindParent<T>(DependencyObject child) where T : DependencyObject
		//{
		//	DependencyObject parentObject = VisualTreeHelper.GetParent(child);

		//	if (parentObject == null)
		//	{
		//		return null;
		//	}

		//	var parent = parentObject as T;

		//	if (parent != null)
		//	{
		//		return parent;
		//	}

		//	return FindParent<T>(parentObject);
		//}
	}
}

