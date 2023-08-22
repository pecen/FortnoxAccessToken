using Csla;
using FortnoxAccessToken.Core.Enums.DAL;
using FortnoxAccessToken.Dal;
using System;

namespace FortnoxAccessToken.Library
{
	[Serializable]
	public class AccessTokenExistsCmd : CommandBase<AccessTokenExistsCmd>
	{
		public static readonly PropertyInfo<string> AuthorizationIdProperty = RegisterProperty<string>(c => c.AuthorizationId);
		private string AuthorizationId
		{
			get { return ReadProperty(AuthorizationIdProperty); }
			set { LoadProperty(AuthorizationIdProperty, value); }
		}

		public static readonly PropertyInfo<bool> AccessTokenExistsProperty = RegisterProperty<bool>(c => c.AccessTokenExists);
		public bool AccessTokenExists
		{
			get { return ReadProperty(AccessTokenExistsProperty); }
			private set { LoadProperty(AccessTokenExistsProperty, value); }
		}

		//public bool HasErrors { get; set; }

		public static readonly PropertyInfo<string> ErrorMessageProperty = RegisterProperty<string>(c => c.ErrorMessage);
		public string ErrorMessage
		{
			get { return ReadProperty(ErrorMessageProperty); }
			private set { LoadProperty(ErrorMessageProperty, value); }
		}

		public AccessTokenExistsCmd()
		{
		}

		public AccessTokenExistsCmd(string authorizationId)
		{
			AuthorizationId = authorizationId;
		}

		[Execute]
		protected override void DataPortal_Execute()
		{
			try
			{
				using (var ctx = DalFactory.GetManager(DalManagerTypes.AuthCodeManager))
				{
					var dal = ctx.GetProvider<IAuthorizationCodeDal>();
					AccessTokenExists = dal.Exists(AuthorizationId);
				}
			}
			catch (Exception ex)
			{
				//HasErrors = true;
				ErrorMessage = ex.Message;
			}
		}
	}
}
