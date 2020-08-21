using HiQoKerioConnectCalendarApiClient.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HiQoKerioConnectCalendarApiClient.RequestEntities.CreateEvent
{
    public class CreateEventParamsEntity
    {
        [JsonProperty(PropertyName = "events")]
        public List<Event> EventEntity { get; set; }

        public CreateEventParamsEntity()
        {
            EventEntity = new List<Event>();
        }
    }
}
