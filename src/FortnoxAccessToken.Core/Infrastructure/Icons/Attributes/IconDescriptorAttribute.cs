using System;

namespace FortnoxAccessToken.Core.Infrastructure.Icons.Attributes
{
	public sealed class IconDescriptorAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the IconCharacterAttribute class.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <param name="altText">The alt text.</param>
		public IconDescriptorAttribute(char character, string altText = null)
		{
			Character = character;
			AltText = altText;
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		public char Character { get; private set; }

		/// <summary>
		/// Gets the alt text.
		/// </summary>
		public string AltText { get; private set; }
	}
}
