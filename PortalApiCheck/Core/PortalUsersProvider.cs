using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using PortalApiCheck.Entity;
using PortalApiCheck.Extensions;
using PortalApiCheck.Interfaces;

namespace PortalApiCheck.Core
{
    public class PortalUsersProvider : IUserProvider
    {
        private const string PREFIX = "PORTAL_";

        private readonly string _baseUrl;
        private readonly PortalApiClient _portalApiClient;

        public PortalUsersProvider(string baseUrl, string encryptedLogin, string encryptedPassword)
        {
            _baseUrl = baseUrl;
            _portalApiClient = new PortalApiClient(baseUrl, encryptedLogin, encryptedPassword);
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            IEnumerable<PortalTeamUserInfo> users = _portalApiClient.GetPortalTeam();
            if (users == null)
                return null;

            //PortalTeamUserInfo have no birthday
            IEnumerable<UserInfo> adUsers = users
                .Select(user => new UserInfo($"{PREFIX}{user.Id}", user.Email, user.FirstName, user.LastName, string.Empty, user.Category?.Name, user.Level, user.Status))
                .ToArray();

            return adUsers;
        }

        public UserInfo GetUserByCredentials(string email, string password)
        {
            var oneTimeClient = new PortalApiClient(_baseUrl, email.EncodeToBase64(), password.EncodeToBase64());

            PortalUserInfo user;
            try
            {
                user = oneTimeClient.GetCurrentUserInfo();
            }
            catch (AuthenticationException)
            {
                return null;
            }

            if (user == null)
                return null;

            PortalProfile userProfile = _portalApiClient.GetUserInfoById(user.UserId);
            if (userProfile == null)
                return null;

            UserInfo adUser = GetUserInfo(userProfile);

            return adUser;
        }

        public UserInfo GetUserByGuid(string guid)
        {
            if (!int.TryParse(guid.Substring(PREFIX.Length), out int id))
                return null;

            PortalProfile userProfile = _portalApiClient.GetUserInfoById(id);

            UserInfo adUser = GetUserInfo(userProfile);

            return adUser;
        }

        private UserInfo GetUserInfo(PortalProfile profile)
        {
            UserInfo adUser = new UserInfo($"{PREFIX}{profile.UserId}", profile.Email, profile.FirstName, profile.LastName, profile.Birthday, profile.Category, profile.Level, profile.Status);
            return adUser;
        }
    }
}
