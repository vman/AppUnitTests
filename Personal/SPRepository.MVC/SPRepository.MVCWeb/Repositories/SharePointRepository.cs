using Microsoft.SharePoint.Client;
using SPRepository.MVCWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SPRepository.MVCWeb.Repositories
{
    public class SharePointRepository : IRepository
    {
        public ClientContext clientContext { get; set; }

        public SharePointRepository(HttpContextBase httpContext)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(httpContext);

            clientContext = spContext.CreateUserClientContextForSPHost();
        }

        public object GetCurrentUserProperty(Expression<Func<User, object>> predicate)
        {
            User spUser = clientContext.Web.CurrentUser;

            clientContext.Load(spUser, predicate);

            clientContext.ExecuteQuery();

            return spUser.Title;
        }

        public UserCollection GetUsers(Expression<Func<UserCollection, object>> predicate)
        {
            var users = clientContext.Web.SiteUsers;
            clientContext.Load(users, usrs => usrs.Include(u => u.LoginName));
            clientContext.ExecuteQuery();
            return users;
        }
    }
}