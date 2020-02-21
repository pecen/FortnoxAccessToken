using Csla;
using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Library {
  [Serializable]
  public class AppConfigInfo : ReadOnlyBase<AppConfigInfo> {
    #region Properties

    public static readonly PropertyInfo<string> DalManagerTypeProperty = RegisterProperty<string>(c => c.DalManagerType);
    public string DalManagerType {
      get { return GetProperty(DalManagerTypeProperty); }
      set { LoadProperty(DalManagerTypeProperty, value); }
    }

    public static readonly PropertyInfo<string> BaseUriProperty = RegisterProperty<string>(c => c.BaseUri);
    public string BaseUri {
      get { return GetProperty(BaseUriProperty); }
      set { LoadProperty(BaseUriProperty, value); }
    }

    public static readonly PropertyInfo<string> ClientSecretProperty = RegisterProperty<string>(c => c.ClientSecret);
    public string ClientSecret {
      get { return GetProperty(ClientSecretProperty); }
      set { LoadProperty(ClientSecretProperty, value); }
    }

    public static readonly PropertyInfo<string> DbInUseProperty = RegisterProperty<string>(c => c.DbInUse);
    public string DbInUse {
      get { return GetProperty(DbInUseProperty); }
      set { LoadProperty(DbInUseProperty, value); }
    }

    #endregion

    #region Factory Methods

    public static AppConfigInfo GetConfigSettings() {
      return DataPortal.Fetch<AppConfigInfo>();
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch() {
      using (var dalManager = DalFactory.GetManager(DalManagerTypes.AppConfigManager)) {
        var dal = dalManager.GetProvider<IAppConfigDal>();
        var data = dal.Fetch();

        DalManagerType = data.DalManagerType;
        BaseUri = data.BaseUri;
        ClientSecret = data.ClientSecret;
        DbInUse = data.DbInUse;
      }
    }

    #endregion
  }
}
