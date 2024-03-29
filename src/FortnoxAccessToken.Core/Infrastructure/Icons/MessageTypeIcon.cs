﻿using FortnoxAccessToken.Core.Infrastructure.Icons.Attributes;

namespace FortnoxAccessToken.Core.Infrastructure.Icons
{
	/// <summary>
	/// Message type icon.
	/// </summary>
	public enum MessageTypeIcon
	{
		/// <summary>
		/// The information.
		/// </summary>
		[IconDescriptor('\uE6a2')]
		Information,

		/// <summary>
		/// The warning.
		/// </summary>
		[IconDescriptor('\uE6a1')]
		Warning,

		/// <summary>
		/// The error.
		/// </summary>
		[IconDescriptor('\ue6a0')]
		Error,
	}
}
