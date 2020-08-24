using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.RequestEntities.CreateEvent
{
    public class CreateEventBodyEntity:JsonRpcBodyBase
    {
        [JsonProperty(PropertyName = "params")]
        public CreateEventParamsEntity Params { get; set; }

        public CreateEventBodyEntity() : base() { }
    }
}
