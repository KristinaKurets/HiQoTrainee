﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using DB.Entity;
using DB.EntityStatus;
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

        public IEnumerable<User> GetAllUsers()
        { 
            IEnumerable<PortalTeamUserInfo> users = _portalApiClient.GetPortalTeam();
            if (users == null)
                return null;

            // PortalTeamUserInfo have no birthday
            IEnumerable<User> adUsers = users
                .Select(user => new User
                {
                    Id = user.Id, 
                    FirstName = user.FirstName, 
                    LastName = user.LastName, 
                    Email = user.Email, 
                    Position = new UserPosition { Type = user.Category.Name },
                    Role = UserRole.User
                })
                .ToArray();

            return adUsers;
        }

        public User GetUserByCredentials(string email, string password)
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

            User addUser = GetUserInfo(userProfile);

            return addUser;
        }

        public User GetUserByID(string guid)
        {
            if (!int.TryParse(guid.Substring(PREFIX.Length), out int id))
                return null;

            PortalProfile userProfile = _portalApiClient.GetUserInfoById(id);

            User adUser = GetUserInfo(userProfile);

            return adUser;
        }


        private User GetUserInfo(PortalProfile profile)
        {
            User adUser = new User
            {
                Id = profile.UserId, 
                FirstName = profile.FirstName, 
                LastName = profile.LastName, 
                Email = profile.Email, 
                Role = UserRole.User,
            };
            return adUser;
        }
    }
}
