using System.Configuration;


namespace HiQoKerioConnectCalendarApiClient.Entities.Extensions
{
    public static class ApplicationInfoExtension
    {
        public static ApplicationInfo FillFromConfiguration(this ApplicationInfo info)
        {
            info.Name = ConfigurationManager.AppSettings["APP_NAME"];
            info.Version = ConfigurationManager.AppSettings["APP_VERSION"];
            info.Vendor = ConfigurationManager.AppSettings["APP_VENDOR"];
            return info;
        }
    }
}
