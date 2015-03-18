using Microsoft.SharePoint.Client;
using SPRepository.MVCWeb.Interfaces;
using SPRepository.MVCWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPRepository.MVCWeb.Services
{
    /// <summary>
    /// "Business" Logic
    /// </summary>
    public class UserService
    {
        IRepository _repository;

        public UserService(HttpContextBase httpContext)
        {
            _repository = new SharePointRepository(httpContext);
        }

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        internal string GetCurrentUserTitle()
        {
            return _repository.GetCurrentUserProperty(u => u.Title).ToString();
        }

        internal GroupCollection GetCurrentUserGroups()
        {
            return _repository.GetCurrentUserProperty(u => u.Groups) as GroupCollection;
        }

        internal UserCollection GetAllUsers()
        {
            return _repository.GetUsers(usrs => usrs.Where(u => u.Id != null));
        }

        internal UserCollection GetAllSiteCollectionAdmins()
        {
            return _repository.GetUsers(usrs => usrs.Where(u => u.IsSiteAdmin == true));
        }

    }
}