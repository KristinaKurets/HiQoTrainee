using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.Entities
{
    public class Credentials
    {
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "application")]
        public ApplicationInfo ApplicationInfo { get; set; }
    }
}
