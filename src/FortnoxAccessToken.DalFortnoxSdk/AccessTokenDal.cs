using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using FortnoxAPILibrary.Connectors;
using System;

namespace FortnoxAccessToken.DalFortnoxSdk
{
	public class AccessTokenDal : IAccessTokenDal
	{
		public AccessTokenDto Fetch(string authorizationId, string clientSecret)
		{
			string accessToken = string.Empty;
			AuthorizationConnector authConnector = null;

			try
			{
				authConnector = new AuthorizationConnector();
				// The following line is the real one to use in live environment
				accessToken = authConnector.GetAccessToken(authorizationId, clientSecret);

				// TEST AREA

				//accessToken = "a6bb30c2-b954-46bf-9c37-83cc9c65f173";

				//var custConnector = new CustomerConnector();
				//custConnector.AccessToken = accessToken;
				//custConnector.ClientSecret = clientSecret;
				//var c = custConnector.Find();

				//var companyConnector = new FortnoxAPILibrary.CompanySettingsConnector();
				//companyConnector.AccessToken = accessToken;
				//companyConnector.ClientSecret = clientSecret;
				//var c =  companyConnector.Get();

				//var contractConnector = new ContractConnector();
				//contractConnector.AccessToken = accessToken;
				//contractConnector.ClientSecret = clientSecret;
				//var res = contractConnector.Find();

				//var costCenterConn = new CostCenterConnector();
				//var supplierConn = new SupplierConnector();

				//costCenterConn.AccessToken = accessToken;
				//supplierConn.AccessToken = accessToken;
				//costCenterConn.ClientSecret = clientSecret;
				//supplierConn.ClientSecret = clientSecret;

				//var c = costCenterConn.Find();
				//var s = supplierConn.Find();

				// END OF TEST AREA

				if (accessToken == string.Empty)
				{
					accessToken = "Denna AuthorizationCode är redan använd, eller har gått ut (giltighetstid = 30 dagar).";
				}
			}
			catch (Exception ex)
			{
				accessToken = ex.Message;
			}

			return new AccessTokenDto
			{
				AccessToken = accessToken,
				HasError = authConnector.HasError ? true : false
			};
		}
	}
}
