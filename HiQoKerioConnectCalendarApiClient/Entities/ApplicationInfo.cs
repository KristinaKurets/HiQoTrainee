using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.Entities
{
    public class ApplicationInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; set; }
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}
