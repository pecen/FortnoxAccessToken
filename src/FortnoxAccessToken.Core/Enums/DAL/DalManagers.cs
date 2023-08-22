using System.ComponentModel;

namespace FortnoxAccessToken.Core.Enums.DAL
{
	public enum DalManagers
	{
		[Description("File")]
		File,
		[Description("SQLite")]
		SQLite,
		[Description("SQL Server")]
		SQLServer,
		//[Description("XML")]
		//XML,
		//[Description("Json")]
		//Json
	}
}
