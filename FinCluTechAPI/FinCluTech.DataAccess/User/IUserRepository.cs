using FinCluTech.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.DataAccess.User
{
    public interface IUserRepository : IBaseRepository<Data.Entities.User, UserBo>
    {
        public Task<UserBo> AuthenticateUser(string userName, string password);
    }
}
