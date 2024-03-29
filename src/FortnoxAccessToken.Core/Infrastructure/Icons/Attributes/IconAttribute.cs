﻿using FortnoxAccessToken.Core.Extensions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FortnoxAccessToken.Core.Infrastructure.Icons.Attributes
{
	/// <summary>
	/// Base icon attribute.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "Base attribute on purpose.")]
	public class IconAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the IconAttribute class.
		/// </summary>
		/// <param name="icon">The icon.</param>
		public IconAttribute(Enum icon)
		{
			Icon = icon;
		}

		/// <summary>
		/// Gets the icon.
		/// </summary>
		public Enum Icon { get; private set; }

		/// <summary>
		/// Gets the character.
		/// </summary>
		public char Character { get { return GetIconDescriptorAttributePropertyValue(x => x.Character); } }

		/// <summary>
		/// Gets the alt text.
		/// </summary>
		public string AltText { get { return GetIconDescriptorAttributePropertyValue(x => x.AltText); } }

		/// <summary>
		/// Gets the icon descriptor attribute property.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="propertySelector">The property selector.</param>
		/// <returns>Property value.</returns>
		private TResult GetIconDescriptorAttributePropertyValue<TResult>(Func<IconDescriptorAttribute, TResult> propertySelector)
		{
			IconDescriptorAttribute iconCharacterAttribute = Icon.GetAttribute<IconDescriptorAttribute>();
			if (iconCharacterAttribute != null)
			{
				return propertySelector(iconCharacterAttribute);
			}
			else
			{
				return default;
			}
		}
	}
}
