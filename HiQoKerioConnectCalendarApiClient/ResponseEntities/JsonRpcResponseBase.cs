using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.ResponseEntities
{
    public class JsonRpcResponseBase
    {
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRPC { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
    }
}
