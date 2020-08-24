using Newtonsoft.Json;


namespace HiQoKerioConnectCalendarApiClient.ResponseEntities.Login
{
    public class LoginResponseResult
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
