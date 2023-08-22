using System.ComponentModel;

namespace FortnoxAccessToken.Core.Enums.DAL
{
	public enum DalManagerTypes
	{
		[Description("DalManagerTypeAuthCode")]
		AuthCodeManager,

		[Description("DalManagerTypeFortnox")]
		FortnoxManager,

		[Description("DalManagerTypeAppConfig")]
		AppConfigManager
	}
}
