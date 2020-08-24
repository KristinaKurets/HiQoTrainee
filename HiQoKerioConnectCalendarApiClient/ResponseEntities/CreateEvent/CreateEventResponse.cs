using Newtonsoft.Json;
using System.Collections.Generic;

namespace HiQoKerioConnectCalendarApiClient.ResponseEntities.CreateEvent
{
    public class CreateEventResponse
    {
        [JsonProperty(PropertyName = "errors")]
        public List<object> Errors;


        [JsonProperty(PropertyName = "result")]
        public List<CreateEventResponseEntity> Results { get; set; }
    }
}
