using FortnoxAccessToken.Library;
using FortnoxAccessToken.UI.Module.Commands;
using FortnoxAccessToken.UI.Module.Models;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FortnoxAccessToken.UI.Module.ViewModels {
  public class GetAccessTokenViewModel : ViewModelBase {
    private IEventAggregator _eventAggregator;
    private readonly string _tabHeader = "<New AuthorizationCode>";

    private string _authorizationId;
    public string AuthorizationId {
      get { return _authorizationId; }
      set {
        SetProperty(ref _authorizationId, value);

        if (Guid.TryParse(value, out Guid result)) {
          Title = value;
        }
        else if(Guid.TryParse(Title, out result) && !Title.Equals(value)) {
          Title = _tabHeader;
        }

        RaisePropertyChanged(nameof(Title));
      }
    }

    private string _clientSecret;
    public string ClientSecret {
      get { return _clientSecret; }
      set { SetProperty(ref _clientSecret, value); }
    }

    private string _accessToken;
    public string AccessToken {
      get { return _accessToken; }
      set {
        SetProperty(ref _accessToken, value);
        RaisePropertyChanged(nameof(HasValue));
      }
    }

    public bool HasValue {
      get {
        return !string.IsNullOrEmpty(AccessToken);
      }
    }

    public DelegateCommand GetAccessTokenCommand { get; set; }

    public GetAccessTokenViewModel(IEventAggregator eventAggregator, IUnityContainer container) {
      _eventAggregator = eventAggregator;

      GetAccessTokenCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => AuthorizationId)
        .ObservesProperty(() => ClientSecret);

      _eventAggregator.GetEvent<UpdateFromConfigCommand>().Subscribe(ClientSecretUpdated);
      _eventAggregator.GetEvent<GetAccessTokenCommand>().Subscribe(AccessTokenReceived);
      //container.Resolve<AppConfigViewModel>();

      Title = _tabHeader;
    }

    private void AccessTokenReceived(string obj) => AccessToken = obj;  
    private void ClientSecretUpdated(string obj) => ClientSecret = obj;

    private bool CanExecute() {
      return !string.IsNullOrWhiteSpace(AuthorizationId) 
        && !string.IsNullOrWhiteSpace(ClientSecret) 
        && Guid.TryParse(AuthorizationId, out Guid guidOutput);
    }

    private void Execute() {
      AccessToken = string.Empty;
      Mouse.OverrideCursor = Cursors.Wait;

      try {
        //_eventAggregator
        //  .GetEvent<GetAccessTokenCommand>()
        //  .Publish(_eventAggregator
        //    .GetEvent<GetAccessTokenCommand>()
        //    .GetAccessToken(new AccessTokenRequest {
        //      AuthorizationId = AuthorizationId,
        //      ClientSecret = ClientSecret
        //    })
        //  );

        _eventAggregator
          .GetEvent<GetAccessTokenCommand>()
          .Publish(GetAccessToken(new AccessTokenRequest {
            AuthorizationId = AuthorizationId,
            ClientSecret = ClientSecret
          }));
      }
      catch(Exception ex) {
        AccessToken = ex.Message;
      }
      finally {
        Mouse.OverrideCursor = Cursors.Arrow;
      }
    }

    public override bool IsNavigationTarget(NavigationContext navigationContext) {
      // By setting this to false a new tab is created, as opposed to true, which 
      // just falls back on the already opened tab. Default value is true, which 
      // means overriding is not necessary if that is the value to be used. 
      return false;
    }

    public string GetAccessToken(AccessTokenRequest request) {
      try {
        bool exists = AccessTokenInfo.Exists(request.AuthorizationId);

        // Check for SQLServer-error
        if (!string.IsNullOrEmpty(AccessTokenInfo.ErrorMessage)) {
          var msg = AccessTokenInfo.ErrorMessage;
          AccessTokenInfo.ErrorMessage = "";
          return msg;
        }

        if (exists) { // = AccessTokenInfo.Exists(request.AuthorizationId)) {
          var answer = MessageBox.Show("The given AuthorizationCode is already used. Do you want to send anyway to deactivate this integration?", //"Den AuthorizationCode som angivits är redan förbrukad. Vill du skicka ändå för att deaktivera denna integration?", 
            "AccessToken existerar",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning,
            MessageBoxResult.No);

          if (answer == MessageBoxResult.No) {
            //return "En AccessToken har redan skapats med given AuthorizationCode.";
            return "Den AuthorizationCode som angivits är redan förbrukad.";
          }
        }

        var accessTokenInfo = AccessTokenInfo.GetAccessToken(request.AuthorizationId, request.ClientSecret);

        if (!accessTokenInfo.HasError && !exists) {
          var authorizationCodeEdit = AuthorizationCodeEdit.NewAuthorizationCode();
          authorizationCodeEdit.AuthorizationCode = request.AuthorizationId;
          authorizationCodeEdit = authorizationCodeEdit.Save();
        }

        return accessTokenInfo.AccessToken;
      }
      catch (Exception ex) {
        throw new Exception(ex.Message);
      }
    }
  }
}
