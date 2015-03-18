using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SPRepository.MVCWeb.Interfaces
{
    public interface IRepository
    {
        object GetCurrentUserProperty(Expression<Func<User, object>> predicate);

        UserCollection GetUsers(Expression<Func<UserCollection, object>> predicate);
    }
}
