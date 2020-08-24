using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.RequestEntities
{
    public class JsonRpcBodyBase
    {
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRPC { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }


        public JsonRpcBodyBase()
        {
            JsonRPC = "2.0";
            ID = 1;
        }
    }
}
