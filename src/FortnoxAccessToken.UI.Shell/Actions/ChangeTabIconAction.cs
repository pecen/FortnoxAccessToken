using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FortnoxAccessToken.UI.Shell.Actions
{
  public class ChangeTabIconAction : BaseTabAction { //TriggerAction<Button> {
    protected override void Invoke(object parameter) {
      var args = parameter as RoutedEventArgs;

      if (args == null) {
        return;
      }

      var tabItem = FindParent<TabItem>(args.OriginalSource as DependencyObject);

      if (tabItem == null) {
        return;
      }

      var tabControl = FindParent<TabControl>(tabItem);

      if (tabControl == null) {
        return;
      }

      //tabControl.Items.Remove(tabItem.Content);

      IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
      if (region == null) {
        return;
      }

      if (region.Views.Contains(tabItem.Content)) {
        region.Remove(tabItem.Content);
      }
    }
  }
}
