using HiQoKerioConnectCalendarApiClient.Entities;
using RestSharp;
using System.Configuration;
using HiQoKerioConnectCalendarApiClient.Entities.Extensions;
using Newtonsoft.Json;
using HiQoKerioConnectCalendarApiClient.ResponseEntities.Login;
using HiQoKerioConnectCalendarApiClient.RequestEntities.Login;
using HiQoKerioConnectCalendarApiClient.RequestEntities.CreateEvent;
using HiQoKerioConnectCalendarApiClient.ResponseEntities.CreateEvent;
using HiQoKerioConnectCalendarApiClient.Interfaces;

namespace HiQoKerioConnectCalendarApiClient.Client
{
    public class HiQoCalendarApiClient:ICalendrAPIClient
    {
        private readonly static string BASE_URL = ConfigurationManager.AppSettings["BASE_API_URL"];
        private readonly static string LOGIN_METHOD = ConfigurationManager.AppSettings["LOGIN_METHOD"];
        private readonly static string CREATE_EVENT_METHOD = ConfigurationManager.AppSettings["CREATE_EVENT_METHOD"];
        
        private readonly RestClient _client;
        private bool Auth;
        
        
        public HiQoCalendarApiClient() {
            _client = new RestClient(BASE_URL)
            {
                CookieContainer = new System.Net.CookieContainer()
            };
            Auth=Authenticate();
        }
        
        protected bool Authenticate()
        {
            var loginToken = Login(ConfigurationManager.AppSettings["AUTH_USERNAME"],ConfigurationManager.AppSettings["BASE_API_URL"]);
            if (loginToken != null) {
                _client.AddDefaultHeader("X-Token", loginToken);
                return true;
            }
            return false;
        }

        // Return Auth Token, null if error
        protected string Login(string userName, string password)
        {
            RestRequest request = new RestRequest(BASE_URL, Method.POST);
            LoginRequestEntity body = new LoginRequestEntity()
            {
                Method = LOGIN_METHOD,
                Params = new Credentials
                {
                    UserName = userName,
                    Password = password,
                    ApplicationInfo = new ApplicationInfo().FillFromConfiguration()
                }
            };
            request.AddJsonBody(JsonConvert.SerializeObject(body));
            IRestResponse response = _client.Execute(request);
            try
            {
                return JsonConvert.DeserializeObject<LoginResponseBody>(response.Content).Result.Token;
            }
            catch  {
                return null;
            }
            
        }

        // Return id of created event, null if error
        protected string CreateEvent(CreateEventParamsEntity eventEntity)
        {
            RestRequest request = new RestRequest(BASE_URL, Method.POST);
            CreateEventBodyEntity body = new CreateEventBodyEntity()
            {
                Method = CREATE_EVENT_METHOD,
                ID = 1,
                Params= eventEntity
                
            };     
            request.AddJsonBody(JsonConvert.SerializeObject(body));
            IRestResponse response = _client.Execute(request);
            try
            {
                return JsonConvert.DeserializeObject<CreateEventResponseBody>(response.Content).Result.Results[0].ID;
            }
            catch  { return null; }
        }

        // Return id of created event, null if error
        // Use EventExtension.Initialize for create Event from order
        public string CreateEvent(Event calendarEvent) {
            if (Auth)
            {
                var eventParams = new CreateEventParamsEntity();
                eventParams.EventEntity.Add(calendarEvent);
                return CreateEvent(eventParams);
            }
            return null;
        }
    }
}
