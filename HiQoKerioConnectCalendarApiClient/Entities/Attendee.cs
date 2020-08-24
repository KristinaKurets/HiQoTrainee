using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.Entities
{
    public class Attendee
    {
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "isNotified")]
        public bool IsNotified { get; set; }

        [JsonProperty(PropertyName = "partStatus")]
        public string PartStatus { get; set; }
    }
}
