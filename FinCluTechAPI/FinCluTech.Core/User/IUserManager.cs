using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.Core.User
{
    public interface IUserManager : IBaseManager<UserBo>
    {
        public Task<ResponseModel> AuthenticateUser(string userName, string passWord);
    }
}
