using FortnoxAccessToken.Library;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.UI.Module.Commands {
  public class SaveAppConfigCommand : PubSubEvent<AppConfigEdit> {
    //public AppConfigEdit SaveConfig(AppConfigEdit data) {
    //  data = data.Save();
    //  return data;
    //}
  }
}
