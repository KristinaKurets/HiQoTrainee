using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using PortalApiCheck.Entity;
using PortalApiCheck.Extensions;
using RestSharp;
using RestSharp.Authenticators;

namespace PortalApiCheck.Core
{
    public class PortalApiClient
    {
        private const string LOGIN = "/login";
        private const string TEAM = "/front/team";
        private const string USER_INFO = "/front/user-info";
        private const string PROFILE = "/front/profile/{0}";

        private readonly bool _tryRelogin;
        private readonly string _encryptedLogin;
        private readonly string _encryptedPassword;
        private readonly RestClient _client;

        public PortalApiClient(string baseUrl, string encryptedLogin, string encryptedPassword, bool tryRelogin = false)
        {
            _tryRelogin = tryRelogin;
            _encryptedLogin = encryptedLogin;
            _encryptedPassword = encryptedPassword;

            _client = new RestClient(baseUrl);
        }

        public IEnumerable<PortalTeamUserInfo> GetPortalTeam()
        {
            var response = GetResponse<IEnumerable<PortalTeamUserInfo>>(TEAM);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new ApplicationException("Portal API doesn't work: " + response.Content);

            IEnumerable<PortalTeamUserInfo> teamUserInfo = response.Data;
            return teamUserInfo;
        }

        public PortalUserInfo GetCurrentUserInfo()
        {
            var response = GetResponse<PortalUserInfo>(USER_INFO);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new ApplicationException("Portal API doesn't work: " + response.Content);

            PortalUserInfo userInfo = response.Data;
            return userInfo;
        }

        public PortalProfile GetUserInfoById(int id)
        {
            var response = GetResponse<PortalProfile>(string.Format(PROFILE, id));

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            else if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new ApplicationException("Portal API doesn't work: " + response.Content);

            PortalProfile userInfo = response.Data;
            return userInfo;
        }

        private IRestResponse<T> GetResponse<T>(string resource)
        {
            if (_client.Authenticator == null)
                Authenticate();

            RestRequest request = new RestRequest(resource, Method.GET);
            IRestResponse<T> response = _client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized && _tryRelogin)
            {
                Authenticate();
                response = _client.Execute<T>(request);
            }

            return response;
        }

        private void Authenticate()
        {
            string token = GetPortalToken(_encryptedLogin.DecodeFromBase64(), _encryptedPassword.DecodeFromBase64());
            _client.Authenticator = new JwtAuthenticator(token);
        }

        private string GetPortalToken(string email, string password)
        {
            RestRequest request = new RestRequest(LOGIN, Method.POST);
            request.AddJsonBody(new { email, password });

            IRestResponse<PortalAuthorizationInfo> response = _client.Execute<PortalAuthorizationInfo>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new AuthenticationException("Wrong Portal user or password");
            if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
                throw new AuthenticationException("Wrong email format");
            else if (response.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException("Portal API doesn't work: " + response.Content);

            return response.Data.Token;
        }
    }
}
