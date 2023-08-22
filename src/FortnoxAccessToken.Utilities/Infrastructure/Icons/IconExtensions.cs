using FortnoxAccessToken.Core.Extensions;
using FortnoxAccessToken.Core.Infrastructure.Icons.Attributes;
using System;

namespace FortnoxAccessToken.Core.Infrastructure.Icons
{
	public static class IconExtensions
	{
		/// <summary>
		/// Gets the icon.
		/// </summary>
		/// <typeparam name="TIcon">The type of the T icon.</typeparam>
		/// <param name="iconCharacter">The icon character.</param>
		/// <returns></returns>
		public static TIcon GetIcon<TIcon>(this char iconCharacter)
		{
			foreach (TIcon icon in Enum.GetValues(typeof(TIcon)))
			{
				if (GetIconCharacter(icon as Enum) == iconCharacter)
				{
					return icon;
				}
			}

			throw new ArgumentException("Invaid character: " + iconCharacter);
		}

		/// <summary>
		/// Gets the icon character.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>Icon character.</returns>
		public static char GetIconCharacter(this Enum value)
		{
			return GetIconPropertyValue(value, x => x.Character, x => x.Character);
		}

		/// <summary>
		/// Gets the alt text.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>Alt text.</returns>
		public static string GetAltText(this Enum value)
		{
			return GetIconPropertyValue(value, x => x.AltText, x => !string.IsNullOrWhiteSpace(x.AltText) ? x.AltText : value.ToString());
		}

		/// <summary>
		/// Gets the icon property value.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="iconPropertySelector">The icon property selector.</param>
		/// <param name="iconDescriptorPropertySelector">The icon descriptor property selector.</param>
		/// <param name="defaultValueSelector">The default value selector.</param>
		/// <returns>Icon property value.</returns>
		private static TResult GetIconPropertyValue<TResult>(Enum value,
			Func<IconAttribute, TResult> iconPropertySelector,
			Func<IconDescriptorAttribute, TResult> iconDescriptorPropertySelector,
			Func<Enum, TResult> defaultValueSelector = null)
		{
			if (value != null)
			{
				IconAttribute iconAttribute = value.GetAttribute<IconAttribute>();
				if (iconAttribute != null)
				{
					return iconPropertySelector(iconAttribute);
				}
				else
				{
					IconDescriptorAttribute iconDescriptorAttribute = value.GetAttribute<IconDescriptorAttribute>();
					if (iconDescriptorAttribute != null)
					{
						return iconDescriptorPropertySelector(iconDescriptorAttribute);
					}
				}
			}

			return defaultValueSelector != null ? defaultValueSelector(value) : default(TResult);
		}
	}
}
