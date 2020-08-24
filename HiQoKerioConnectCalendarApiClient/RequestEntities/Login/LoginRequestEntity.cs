using HiQoKerioConnectCalendarApiClient.Entities;
using Newtonsoft.Json;

namespace HiQoKerioConnectCalendarApiClient.RequestEntities.Login
{
    public class LoginRequestEntity : JsonRpcBodyBase
    {

        [JsonProperty(PropertyName = "params")]
        public Credentials Params { get; set; }
        public LoginRequestEntity() : base() {
        
        }
    }
}
