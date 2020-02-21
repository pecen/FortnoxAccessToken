using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace FortnoxAccessToken.UI.Shell.Actions
{
  public class BaseTabAction : TriggerAction<Button> {
    protected override void Invoke(object parameter) {
    }

    protected static T FindParent<T>(DependencyObject child) where T : DependencyObject {
      DependencyObject parentObject = VisualTreeHelper.GetParent(child);

      if (parentObject == null) {
        return null;
      }

      if (parentObject is T parent) {
        return parent;
      }

      return FindParent<T>(parentObject);
    }
  }
}
