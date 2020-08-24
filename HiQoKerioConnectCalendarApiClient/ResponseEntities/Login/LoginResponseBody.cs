using Newtonsoft.Json;


namespace HiQoKerioConnectCalendarApiClient.ResponseEntities.Login
{
    public class LoginResponseBody:JsonRpcResponseBase
    {
        [JsonProperty(PropertyName = "result")]
        public LoginResponseResult Result { get; set; }
    }
}