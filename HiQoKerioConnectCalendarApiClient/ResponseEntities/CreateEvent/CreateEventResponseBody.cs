using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.ResponseEntities.CreateEvent
{
    public class CreateEventResponseBody:JsonRpcResponseBase
    {
        [JsonProperty(PropertyName = "result")]
        public CreateEventResponse Result { get; set; }

    }
}
