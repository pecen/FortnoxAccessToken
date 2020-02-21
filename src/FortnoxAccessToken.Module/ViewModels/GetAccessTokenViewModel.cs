using FortnoxAccessToken.Module.Commands;
using FortnoxAccessToken.Module.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Module.ViewModels {
  public class GetAccessTokenViewModel : BindableBase {
    private string _authorizationId;
    public string AuthorizationId {
      get { return _authorizationId; }
      set { SetProperty(ref _authorizationId, value); }
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
        RaisePropertyChanged("HasValue");
      }
    }

    public bool HasValue {
      get {
        return !string.IsNullOrEmpty(AccessToken);
      }
    }

    private IEventAggregator _eventAggregator;

    public DelegateCommand GetAccessTokenCommand { get; set; }

    public GetAccessTokenViewModel(IEventAggregator eventAggregator) {
      _eventAggregator = eventAggregator;

      GetAccessTokenCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => AuthorizationId)
        .ObservesProperty(() => ClientSecret);

      //AuthorizationId = "AuthorizationId from your Prism Module";
      //ClientSecret = "ClientSecret from your Prism Module";
      //AccessToken = Guid.NewGuid().ToString();

      ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
    }

    private bool CanExecute() {
      return !string.IsNullOrWhiteSpace(AuthorizationId) && !string.IsNullOrWhiteSpace(ClientSecret);
    }

    private void Execute() {
      AccessToken = string.Empty;
      //AccessToken = Guid.NewGuid().ToString();

      _eventAggregator.GetEvent<GetAccessTokenCommand>().Publish("");
      AccessToken = _eventAggregator
        .GetEvent<GetAccessTokenCommand>()
        .GetAccessToken(new AccessTokenRequest {
          AuthorizationId = AuthorizationId,
          ClientSecret = ClientSecret
        });

      //var accessTokenEdit = _eventAggregator
      //  .GetEvent<GetAccessTokenCommand>()
      //  .GetAccessToken(new AccessTokenRequest {
      //    AuthorizationId = AuthorizationId,
      //    ClientSecret = ClientSecret
      //  });

      //AccessToken = accessTokenEdit.AccessToken;
    }
  }
}
