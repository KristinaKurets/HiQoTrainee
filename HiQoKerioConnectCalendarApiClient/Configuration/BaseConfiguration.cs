using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace HiQoKerioConnectCalendarApiClient.Configuration
{
	public static class BaseConfiguration
	{
		public const string BASE_API_URL ="https://mail.hiqo-solutions.com:443/webmail/api/jsonrpc/";
		public const string LOGIN_METHOD = "Session.login";
		public const string CREATE_EVENT_METHOD = "Events.create";
		public const string APP_NAME = "HiQo Kerio Connect API Calendar Clinet";
		public const string APP_VERSION = "0.2";
		public const string APP_VENDOR = "HiQo Solutions";
		public const string AUTH_USERNAME = "TUTEMAIL";
		public const string AUTH_PASSWORD = "TUTPASSWORD";
		public const string FOLDER_ID = "TUTFOLDERID";
		public const string ORG_EMAIL = "TUTTOJEEMAIL";
		public const string ORG_DISPLAY_NAME = "HiQo Remote Booking";
		/*
		public static string BASE_API_URL = ConfigurationManager.AppSettings["KCCA_BASE_API_URL"];
		public static string LOGIN_METHOD = ConfigurationManager.AppSettings["KCCA_LOGIN_METHOD"];
		public static string CREATE_EVENT_METHOD = ConfigurationManager.AppSettings["KCCA_CREATE_EVENT_METHOD"];
		public static string APP_NAME = ConfigurationManager.AppSettings["KCCA_APP_NAME"];
		public static string APP_VERSION = ConfigurationManager.AppSettings["KCCA_APP_VERSION"];
		public static string APP_VENDOR = ConfigurationManager.AppSettings["KCCA_APP_VENDOR"];
		public static string AUTH_USERNAME = ConfigurationManager.AppSettings["KCCA_AUTH_USERNAME"];
		public static string AUTH_PASSWORD = ConfigurationManager.AppSettings["KCCA_AUTH_PASSWORD"];
		public static string FOLDER_ID = ConfigurationManager.AppSettings["KCCA_FOLDER_ID"];
		public static string ORG_EMAIL = ConfigurationManager.AppSettings["KCCA_ORG_EMAIL"];
		public static string ORG_DISPLAY_NAME =ConfigurationManager.AppSettings["KCCA_ORG_DISPLAY_NAME"];*/
	}
}
