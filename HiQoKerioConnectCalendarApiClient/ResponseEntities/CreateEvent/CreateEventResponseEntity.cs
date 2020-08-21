using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.ResponseEntities.CreateEvent
{
    public class CreateEventResponseEntity
    {
        [JsonProperty(PropertyName = "inputIndex")]
        public long InputIndex { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "watermark")]
        public long Watermark { get; set; }
    }
}
