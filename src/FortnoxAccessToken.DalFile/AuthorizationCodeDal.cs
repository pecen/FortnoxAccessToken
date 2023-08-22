using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using System;
using System.IO;
using System.Linq;

namespace FortnoxAccessToken.DalFile
{
	public class AuthorizationCodeDal : IAuthorizationCodeDal
	{
		private readonly string fileName = "AuthorizationCodes.txt";

		//public AccessTokenDto Fetch(string authorizationId, string clientSecret) {
		//  string accessToken = string.Empty;
		//  AuthorizationConnector authConnector = null;

		//  try {
		//    authConnector = new AuthorizationConnector();
		//    accessToken = authConnector.GetAccessToken(authorizationId, clientSecret);

		//    if (accessToken == string.Empty) {
		//      accessToken = "Denna AuthorizationCode är redan använd, eller har gått ut (giltighetstid = 30 dagar).";
		//    }
		//  }
		//  catch (Exception ex) {
		//    accessToken = ex.Message;
		//  }

		//  return new AccessTokenDto {
		//    AccessToken = accessToken,
		//    HasError = authConnector.HasError ? true : false
		//  };
		//}

		public bool Exists(string authorizationId)
		{
			if (!File.Exists(fileName))
			{
				return false;
			}

			try
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					string line = sr.ReadToEnd();
					string[] strarr = line.Replace("\r\n", "").Split(new char[] { ';' });
					if (strarr.Contains(authorizationId))
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return false;
		}

		public void Insert(AuthorizationCodeDto data)
		{
			try
			{
				using (StreamWriter file = new StreamWriter(fileName, true))
				{
					file.WriteLine($"{data.AuthorizationCode};");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
