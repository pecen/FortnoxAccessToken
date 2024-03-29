﻿using FortnoxAccessToken.Core.Enums.DAL;
using DalManager = FortnoxAccessToken.Core.Enums.DAL.DalManagers;
using FortnoxAccessToken.Core.Extensions;
using FortnoxAccessToken.Core.MVVM;
using FortnoxAccessToken.Library;
using FortnoxAccessToken.UI.Module.Commands;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FortnoxAccessToken.UI.Module.ViewModels
{
	public class AppConfigViewModel : ViewModelBase, IConfirmNavigationRequest
	{
		private IEventAggregator _eventAggregator;
		public ObservableCollection<string> DalManagers { get; private set; }
		public ObservableCollection<string> SqlServerInstances { get; private set; }


		private int _dalManagerInUse;
		public int DalManagerInUse
		{
			get { return _dalManagerInUse; }
			set
			{
				SetProperty(ref _dalManagerInUse, value);
				if (value == (int)DalManager.SQLServer)
				{ // || value == (int)Enums.DalManagers.SQLite) {
					IsDatabase = true;
				}
				else
				{
					IsDatabase = false;
				}
			}
		}

		private string _baseUri;
		public string BaseUri
		{
			get { return _baseUri; }
			set { SetProperty(ref _baseUri, value); }
		}

		private string _clientSecret;
		public string ClientSecret
		{
			get { return _clientSecret; }
			set
			{
				SetProperty(ref _clientSecret, value);
				_eventAggregator.GetEvent<UpdateFromConfigCommand>().Publish(ClientSecret);
			}
		}

		private int _dbInUse;
		public int DbInUse
		{
			get { return _dbInUse; }
			set { SetProperty(ref _dbInUse, value); }
		}

		private bool _isDatabase;
		public bool IsDatabase
		{
			get { return _isDatabase; }
			set { SetProperty(ref _isDatabase, value); }
		}

		public AppConfigEdit ConfigEdit { get; set; }
		//public AppConfigInfo ConfigInfo { get; set; }

		public DelegateCommand SaveConfigCommand { get; set; }

		public AppConfigViewModel(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;

			SaveConfigCommand = new DelegateCommand(Execute, CanExecute)
				.ObservesProperty(() => BaseUri)
				.ObservesProperty(() => ClientSecret);

			_eventAggregator.GetEvent<GetConfigSettingsCommand>().Subscribe(AppConfigUpdated);
			_eventAggregator.GetEvent<SaveAppConfigCommand>().Subscribe(AppConfigUpdated);
			_eventAggregator.GetEvent<GetConfigSettingsCommand>().Publish(AppConfigEdit.GetConfigSettings());
			_eventAggregator.GetEvent<UpdateFromConfigCommand>().Publish(ClientSecret);

			Title = "Config";
		}

		//private void AppConfigUpdated(AppConfigInfo obj) => ConfigInfo = obj;
		private void AppConfigUpdated(AppConfigEdit obj)
		{
			ConfigEdit = obj;

			DalManagers = new ObservableCollection<string>();
			foreach (DalManager item in Enum.GetValues(typeof(DalManager)))
			{
				DalManagers.Add(item.GetEnumDescription());
			}

			SqlServerInstances = new ObservableCollection<string>();
			foreach (SQLServerInstances item in Enum.GetValues(typeof(SQLServerInstances)))
			{
				SqlServerInstances.Add(item.GetEnumDescription());
			}

			if (ConfigEdit.DalManagerType == DalManagerConnectionStrings.DalSql.GetEnumDescription())
			{
				DalManagerInUse = (int)DalManager.SQLServer;
			}
			else if (ConfigEdit.DalManagerType == DalManagerConnectionStrings.DalFile.GetEnumDescription())
			{
				DalManagerInUse = (int)DalManager.File;
			}

			BaseUri = ConfigEdit.BaseUri;
			ClientSecret = ConfigEdit.ClientSecret;

			if (ConfigEdit.DbInUse == SQLServerInstances.Local.GetEnumDescription())
			{
				DbInUse = (int)SQLServerInstances.Local;
			}
			else
			{
				DbInUse = (int)SQLServerInstances.Server;
			}
		}

		private bool CanExecute()
		{
			return !string.IsNullOrWhiteSpace(BaseUri) && !string.IsNullOrEmpty(ClientSecret);
		}

		private void Execute()
		{
			if (DalManagerInUse == (int)DalManager.File)
			{
				ConfigEdit.DalManagerType = DalManagerConnectionStrings.DalFile.GetEnumDescription();
			}
			else if (DalManagerInUse == (int)DalManager.SQLServer)
			{
				ConfigEdit.DalManagerType = DalManagerConnectionStrings.DalSql.GetEnumDescription();
			}
			else if (DalManagerInUse == (int)DalManager.SQLite)
			{
				ConfigEdit.DalManagerType = DalManagerConnectionStrings.DalSQLite.GetEnumDescription();
			}
			ConfigEdit.BaseUri = BaseUri;
			ConfigEdit.ClientSecret = ClientSecret;
			if (IsDatabase)
			{
				if (DbInUse == (int)SQLServerInstances.Local)
				{
					ConfigEdit.DbInUse = SQLServerInstances.Local.ToString();
				}
				else if (DbInUse == (int)SQLServerInstances.Server)
				{
					ConfigEdit.DbInUse = SQLServerInstances.Server.ToString();
				}
			}

			Mouse.OverrideCursor = Cursors.Wait;

			try
			{
				//_eventAggregator
				//  .GetEvent<SaveAppConfigCommand>()
				//  .Publish(_eventAggregator
				//    .GetEvent<SaveAppConfigCommand>()
				//    .SaveConfig(ConfigEdit)
				//  );

				_eventAggregator
					.GetEvent<SaveAppConfigCommand>()
					.Publish(SaveConfig(ConfigEdit));

				MessageBox.Show("Configuration saved!", "Fortnox AccessToken Configuration", MessageBoxButton.OK);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred while saving. The application returned: {ex.Message}");
			}
			finally
			{
				Mouse.OverrideCursor = Cursors.Arrow;
			}
		}

		public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
		{
			// By setting this to false, the tab cannot be closed. 
			continuationCallback(true);
		}

		public AppConfigEdit SaveConfig(AppConfigEdit data)
		{
			data = data.Save();
			return data;
		}
	}
}
