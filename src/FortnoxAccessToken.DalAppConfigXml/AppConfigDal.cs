using FortnoxAccessToken.Dal;
using FortnoxAccessToken.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.DalAppConfigXml {
  public class AppConfigDal : IAppConfigDal {
    public AppConfigDto Fetch() {
      return new AppConfigDto {
        DalManagerType = ConfigurationManager.AppSettings["DalManagerTypeAuthCode"],
        BaseUri = ConfigurationManager.AppSettings["WSBaseUri"],
        ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
        DbInUse = ConfigurationManager.AppSettings["DbInUse"]
      };
    }

    public void Insert(AppConfigDto data) {
      throw new NotImplementedException();
    }

    public void Update(AppConfigDto data) {
      // Open App.Config of executable
      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      // Add Application Settings.
      config.AppSettings.Settings.Remove("DalManagerTypeAuthCode");
      config.AppSettings.Settings.Add("DalManagerTypeAuthCode", data.DalManagerType);
      config.AppSettings.Settings.Remove("WSBaseUri");
      config.AppSettings.Settings.Add("WSBaseUri", data.BaseUri);
      config.AppSettings.Settings.Remove("ClientSecret");
      config.AppSettings.Settings.Add("ClientSecret", data.ClientSecret);
      config.AppSettings.Settings.Remove("DbInUse");
      config.AppSettings.Settings.Add("DbInUse", data.DbInUse);
      // Save the configuration file.
      config.Save(ConfigurationSaveMode.Modified);
      // Force a reload of a changed section.
      ConfigurationManager.RefreshSection("appSettings");
    }
  }
}
