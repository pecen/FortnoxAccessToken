using System.ComponentModel;

namespace FortnoxAccessToken.Core.Enums.DAL
{
	public enum DalManagerConnectionStrings
	{
		[Description("FortnoxAccessToken.DalFile.DalManager,FortnoxAccessToken.DalFile")]
		DalFile,

		[Description("FortnoxAccessToken.DalSQLite.DalManager,FortnoxAccessToken.DalSQLite")]
		DalSQLite,

		[Description("FortnoxAccessToken.DalSql.DalManager,FortnoxAccessToken.DalSql")]
		DalSql,

		[Description("FortnoxAccessToken.DalAppConfigXml.DalManager,FortnoxAccessToken.DalAppConfigXml")]
		DalAppConfigXml,

		[Description("FortnoxAccessToken.DalFortnoxSdk.DalManager,FortnoxAccessToken.DalFortnoxSdk")]
		DalFortnoxSdk
	}
}
