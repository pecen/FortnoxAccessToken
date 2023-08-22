using FortnoxAccessToken.Core.Enums.DAL;
using FortnoxAccessToken.Core.Extensions;
using System;
using System.Configuration;

namespace FortnoxAccessToken.Dal
{
	public class DalFactory
	{
		private static Type _dalType;

		public static IDalManager GetManager(DalManagerTypes manager)
		{
			string dalTypeName = ConfigurationManager.AppSettings[manager.GetEnumDescription()];

			if (_dalType == null || _dalType.FullName != dalTypeName.Split(',')[0])
			{
				if (!string.IsNullOrEmpty(dalTypeName))
					_dalType = Type.GetType(dalTypeName);
				else
					throw new NullReferenceException("DalManager");
				if (_dalType == null)
					throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
			}

			return (IDalManager)Activator.CreateInstance(_dalType);
		}
	}
}
