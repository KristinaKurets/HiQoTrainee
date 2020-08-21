using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace HiQoKerioConnectCalendarApiClient.Entities
{
    public class Event
    {
        [JsonProperty(PropertyName = "folderId")]
        public string FolderID { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "attendees")]
        public List<Attendee> Attendees { get; set; }

        [JsonProperty(PropertyName = "start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public DateTimeOffset End { get; set; }

        [JsonProperty(PropertyName = "isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty(PropertyName = "isAllDay")]
        public bool IsAllDay { get; set; }

    }
}
