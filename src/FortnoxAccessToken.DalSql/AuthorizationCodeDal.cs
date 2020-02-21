using Csla.Data;
using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.DalSql {
  public class AuthorizationCodeDal : IAuthorizationCodeDal {
    public bool Exists(string authorizationId) {
      //try {
        using (var ctx = ConnectionManager<SqlConnection>.GetManager(ConfigurationManager.AppSettings["DbInUse"])) {
          var cm = ctx.Connection.CreateCommand();
          cm.CommandType = System.Data.CommandType.Text;
          cm.CommandText = "SELECT AuthorizationCode FROM AuthorizationCodes WHERE AuthorizationCode=@authorizationId";
          cm.Parameters.AddWithValue("@authorizationId", authorizationId);

          string retval = (string)cm.ExecuteScalar();
          return (!string.IsNullOrEmpty(retval));
        }
      //}
      //catch (Exception ex) {
      //  throw new Exception(ex.Message); //, ex.InnerException);
      //}
    }  

    //public AccessTokenDto Fetch(string authorizationId, string clientSecret) {
    //  string accessToken = string.Empty;
    //  AuthorizationConnector authConnector = null;

    //  try {
    //    authConnector = new AuthorizationConnector();
    //    // The following line is the real one to use in live environment
    //    accessToken = authConnector.GetAccessToken(authorizationId, clientSecret);

    //    // TEST AREA

    //    //accessToken = "a6bb30c2-b954-46bf-9c37-83cc9c65f173";

    //    //var custConnector = new CustomerConnector();
    //    //custConnector.AccessToken = accessToken;
    //    //custConnector.ClientSecret = clientSecret;
    //    //var c = custConnector.Find();

    //    //var companyConnector = new FortnoxAPILibrary.CompanySettingsConnector();
    //    //companyConnector.AccessToken = accessToken;
    //    //companyConnector.ClientSecret = clientSecret;
    //    //var c =  companyConnector.Get();

    //    //var contractConnector = new ContractConnector();
    //    //contractConnector.AccessToken = accessToken;
    //    //contractConnector.ClientSecret = clientSecret;
    //    //var res = contractConnector.Find();

    //    //var costCenterConn = new CostCenterConnector();
    //    //var supplierConn = new SupplierConnector();

    //    //costCenterConn.AccessToken = accessToken;
    //    //supplierConn.AccessToken = accessToken;
    //    //costCenterConn.ClientSecret = clientSecret;
    //    //supplierConn.ClientSecret = clientSecret;

    //    //var c = costCenterConn.Find();
    //    //var s = supplierConn.Find();

    //    // END OF TEST AREA

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

    public void Insert(AuthorizationCodeDto data) {
      using (var ctx = ConnectionManager<SqlConnection>.GetManager(ConfigurationManager.AppSettings["DbInUse"])) {
        using (var cm = ctx.Connection.CreateCommand()) {
          cm.CommandType = System.Data.CommandType.Text;
          cm.CommandText = "INSERT INTO AuthorizationCodes (AuthorizationCode,Date) VALUES (@authorizationCode,@date)";
          cm.Parameters.AddWithValue("@authorizationCode", data.AuthorizationCode);
          cm.Parameters.AddWithValue("@date", DateTimeOffset.Now);
          cm.ExecuteNonQuery();
          //cm.Parameters.Clear();
          //cm.CommandText = "SELECT @@identity";
          //var r = cm.ExecuteScalar();
          //var newId = int.Parse(r.ToString());
          //data.Id = newId;
        }
      }
    }
  }
}
