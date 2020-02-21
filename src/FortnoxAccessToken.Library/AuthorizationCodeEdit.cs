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
  public class AuthorizationCodeEdit : BusinessBase<AuthorizationCodeEdit> {
    #region Properties

    public static readonly PropertyInfo<string> AuthorizationCodeProperty = RegisterProperty<string>(c => c.AuthorizationCode);
    public string AuthorizationCode {
      get { return GetProperty(AuthorizationCodeProperty); }
      set { SetProperty(AuthorizationCodeProperty, value); }
    }

    #endregion

    #region Factory Methods

    public static AuthorizationCodeEdit NewAuthorizationCode() {
      return DataPortal.Create<AuthorizationCodeEdit>();
    }

    //public static AccessTokenEdit GetAccessToken(string authorizationId, string clientSecret) {
    //  return DataPortal.Fetch<AccessTokenEdit>(new AccessTokenCriteria(authorizationId, clientSecret));
    //}

    #endregion

    #region Data Access

    protected override void DataPortal_Create() {
      using (BypassPropertyChecks) {
        AuthorizationCode = string.Empty;
      }

      base.DataPortal_Create();
    }

    //private void DataPortal_Fetch(AccessTokenCriteria criteria) {
    //  using (var dalManager = DalFactory.GetManager()) {
    //    var dal = dalManager.GetProvider<IAccessTokenDal>();
    //    var data = dal.Fetch(criteria.AuthorizationId, criteria.ClientSecret);
    //    //AccessToken = dal.Fetch(criteria.AuthorizationId, criteria.ClientSecret);

    //    AccessToken = data.AccessToken;
    //    HasError = data.HasError;
    //  }
    //}

    protected override void DataPortal_Insert() {
      using (var dalManager = DalFactory.GetManager(DalManagerTypes.AuthCodeManager)) {
        var dal = dalManager.GetProvider<IAuthorizationCodeDal>();
        using (BypassPropertyChecks) {
          var data = new AuthorizationCodeDto {
             AuthorizationCode = AuthorizationCode
          };
          dal.Insert(data);
        }
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
