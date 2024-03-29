﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FortnoxAccessToken.UI.Module.Converters
{
	public class BoolToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//  if((bool)value) { //string.IsNullOrEmpty((string)parameter)) {
			//    return Visibility.Visible;
			//  }

			//  return Visibility.Collapsed;
			//}

			return (bool)value ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
