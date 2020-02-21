using FortnoxAccessToken.Dal.Enums;
using FortnoxAccessToken.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Dal {
  public class DalFactory {
    private static Type _dalType;

    public static IDalManager GetManager(DalManagerTypes manager) {
      string dalTypeName = ConfigurationManager.AppSettings[EnumUtilities.GetEnumDescription(manager)];

      if (_dalType == null || _dalType.FullName != dalTypeName.Split(',')[0]) {
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
