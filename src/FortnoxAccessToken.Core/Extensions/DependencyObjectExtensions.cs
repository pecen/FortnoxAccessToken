using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FortnoxAccessToken.Core.Extensions
{
	public static class DependencyObjectExtensions
	{
		public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
		{
			DependencyObject parentObject = VisualTreeHelper.GetParent(child);

			if (parentObject == null)
			{
				return null;
			}

			if (parentObject is T parent)
			{
				return parent;
			}

			return parentObject.FindParent<T>();
		}
	}
}
