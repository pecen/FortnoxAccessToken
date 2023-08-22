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
  public class AppConfigEdit : BusinessBase<AppConfigEdit> {
    #region Properties

    public static readonly PropertyInfo<string> DalManagerTypeProperty = RegisterProperty<string>(c => c.DalManagerType);
    public string DalManagerType {
      get { return GetProperty(DalManagerTypeProperty); }
      set { SetProperty(DalManagerTypeProperty, value); }
    }

    public static readonly PropertyInfo<string> BaseUriProperty = RegisterProperty<string>(c => c.BaseUri);
    public string BaseUri {
      get { return GetProperty(BaseUriProperty); }
      set { SetProperty(BaseUriProperty, value); }
    }

    public static readonly PropertyInfo<string> ClientSecretProperty = RegisterProperty<string>(c => c.ClientSecret);
    public string ClientSecret {
      get { return GetProperty(ClientSecretProperty); }
      set { SetProperty(ClientSecretProperty, value); }
    }

    public static readonly PropertyInfo<string> DbInUseProperty = RegisterProperty<string>(c => c.DbInUse);
    public string DbInUse {
      get { return GetProperty(DbInUseProperty); }
      set { SetProperty(DbInUseProperty, value); }
    }

    #endregion

    #region Factory Methods

    public static AppConfigEdit NewAppConfig() {
      return DataPortal.Create<AppConfigEdit>();
    }

    public static AppConfigEdit GetConfigSettings() {
      return DataPortal.Fetch<AppConfigEdit>();
    }

    #endregion

    #region Data Access

    [RunLocal]
		[Create]
    protected override void DataPortal_Create() {
      base.DataPortal_Create();
    }

		[Fetch]
    private void DataPortal_Fetch() {
      using (var dalManager = DalFactory.GetManager(DalManagerTypes.AppConfigManager)) {
        var dal = dalManager.GetProvider<IAppConfigDal>();
        var data = dal.Fetch();
        using (BypassPropertyChecks) {
          DalManagerType = data.DalManagerType;
          BaseUri = data.BaseUri;
          ClientSecret = data.ClientSecret;
          DbInUse = data.DbInUse;
        }
      }
    }

		[Insert]
    protected override void DataPortal_Insert() {
      using (var ctx = DalFactory.GetManager(DalManagerTypes.AppConfigManager)) {
        var dal = ctx.GetProvider<Dal.IAppConfigDal>();
        using (BypassPropertyChecks) {
          var item = new AppConfigDto {
            BaseUri = BaseUri,
            ClientSecret = ClientSecret,
            DalManagerType = DalManagerType,
            DbInUse = DbInUse
          };
          dal.Insert(item);
        }
      }
    }

		[Update]
    protected override void DataPortal_Update() {
      using (var ctx = DalFactory.GetManager(DalManagerTypes.AppConfigManager)) {
        var dal = ctx.GetProvider<IAppConfigDal>();
        using (BypassPropertyChecks) {
          var item = new AppConfigDto {
            BaseUri = BaseUri,
            ClientSecret = ClientSecret,
            DalManagerType = DalManagerType,
            DbInUse = DbInUse
          };
          dal.Update(item);
        }
      }
    }

    //protected override void DataPortal_DeleteSelf() {
    //  using (BypassPropertyChecks)
    //    DataPortal_Delete(this.Id);
    //}

    //private void DataPortal_Delete(int id) {
    //  using (var ctx = ProjectTracker.Dal.DalFactory.GetManager()) {
    //    Resources.Clear();
    //    FieldManager.UpdateChildren(this);
    //    var dal = ctx.GetProvider<ProjectTracker.Dal.IProjectDal>();
    //    dal.Delete(id);
    //  }
    //}

    #endregion
  }
}
