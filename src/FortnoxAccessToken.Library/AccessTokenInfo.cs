using Csla;
using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using FortnoxAccessToken.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Library {
  [Serializable]
  public class AccessTokenInfo : ReadOnlyBase<AccessTokenInfo> {
    #region Properties

    public static readonly PropertyInfo<string> AccessTokenProperty = RegisterProperty<string>(c => c.AccessToken);
    public string AccessToken {
      get { return GetProperty(AccessTokenProperty); }
      set { LoadProperty(AccessTokenProperty, value); }
    }

    public bool HasError { get; set; }
    public static string ErrorMessage { get; set; }

    //public static readonly PropertyInfo<string> ErrorMessageProperty = RegisterProperty<string>(c => c.ErrorMessage);
    //public string ErrorMessage {
    //  get { return GetProperty(ErrorMessageProperty); }
    //  set { LoadProperty(ErrorMessageProperty, value); }
    //}

    #endregion

    #region Factory Methods

    public static AccessTokenInfo GetAccessToken(string authorizationId, string clientSecret) {
      return DataPortal.Fetch<AccessTokenInfo>(new AccessTokenCriteria(authorizationId, clientSecret));
    }

    /// <summary>
    /// Checks if an AccessToken is generated with the specified AuthorizationCode
    /// </summary>
    /// <param name="authorizationCode"></param>
    /// <returns></returns>
    public static bool Exists(string authorizationCode) {
			var cmd = DataPortal.Create<AccessTokenExistsCmd>(authorizationCode); // new AccessTokenExistsCmd(authorizationCode);
      cmd = DataPortal.Execute(cmd);

      if (!string.IsNullOrEmpty(cmd.ErrorMessage)) {
        ErrorMessage = cmd.ErrorMessage;
        return false;
      }

      return cmd.AccessTokenExists;
    }

		#endregion

		#region Data Access

		[Fetch]
    private void DataPortal_Fetch(AccessTokenCriteria criteria) {
      try {
        using (var dalManager = DalFactory.GetManager(DalManagerTypes.FortnoxManager)) {
          var dal = dalManager.GetProvider<IAccessTokenDal>();
          var data = dal.Fetch(criteria.AuthorizationId, criteria.ClientSecret);

          AccessToken = data.AccessToken;
          HasError = data.HasError;
        }
      }
      catch (Exception ex) {
        AccessToken = ex.Message;
        HasError = true;
      }
    }

    #endregion

    #region Criteria

    [Serializable]
    public class AccessTokenCriteria : CriteriaBase<AccessTokenCriteria> {
      public static readonly PropertyInfo<string> AuthorizationIdProperty = RegisterProperty<string>(c => c.AuthorizationId);
      public string AuthorizationId {
        get { return ReadProperty(AuthorizationIdProperty); }
        set { LoadProperty(AuthorizationIdProperty, value); }
      }

      public static readonly PropertyInfo<string> ClientSecretProperty = RegisterProperty<string>(c => c.ClientSecret);
      public string ClientSecret {
        get { return ReadProperty(ClientSecretProperty); }
        set { LoadProperty(ClientSecretProperty, value); }
      }

      public AccessTokenCriteria(string authorizationId, string clientSecret) {
        AuthorizationId = authorizationId;
        ClientSecret = clientSecret;
      }
    }

    #endregion
  }
}
