using Microsoft.Xaml.Behaviors;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FortnoxAccessToken.Core.Extensions;

namespace FortnoxAccessToken.UI.Shell.Actions
{
	public class ChangeTabIconAction : TriggerAction<Button>
	{
		protected override void Invoke(object parameter)
		{
			var args = parameter as RoutedEventArgs;

			if (args == null)
			{
				return;
			}

			var tabItem = (args.OriginalSource as DependencyObject).FindParent<TabItem>();

			if (tabItem == null)
			{
				return;
			}

			var tabControl = tabItem.FindParent<TabControl>();

			if (tabControl == null)
			{
				return;
			}

			//tabControl.Items.Remove(tabItem.Content);

			IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
			if (region == null)
			{
				return;
			}

			if (region.Views.Contains(tabItem.Content))
			{
				region.Remove(tabItem.Content);
			}
		}
	}
}
