using HiQoKerioConnectCalendarApiClient.Configuration;


namespace HiQoKerioConnectCalendarApiClient.Entities.Extensions
{
    public static class ApplicationInfoExtension
    {
        public static ApplicationInfo FillFromConfiguration(this ApplicationInfo info)
        {
            info.Name = BaseConfiguration.APP_NAME;
            info.Version = BaseConfiguration.APP_VERSION;
            info.Vendor = BaseConfiguration.APP_VENDOR;
            return info;
        }
    }
}
