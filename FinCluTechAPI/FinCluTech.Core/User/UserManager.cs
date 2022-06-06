using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using FinCluTech.DataAccess.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.Core.User
{
    public class UserManager : BaseManager<UserBo>, IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel> AuthenticateUser(string userName, string passWord)
        {
            var res = await _userRepository.AuthenticateUser(userName, passWord);
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = 1
            };
            return resObj;
        }

        public override async Task<ResponseModel> Delete(int ID)
        {
            var res = await _userRepository.Delete(ID);
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = 1
            };
            return resObj;
        }

        public override async Task<ResponseModel> Get(int ID)
        {
            var res = await _userRepository.Get(ID);
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = 1
            };
            return resObj;
        }

        public override async Task<ResponseModel> GetAll()
        {
            var res = await _userRepository.GetAll();
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = res.Count
            };
            return resObj;
        }

        public override async Task<ResponseModel> Save(UserBo item)
        {
            UserValidator validator = new UserValidator();
            var validationResult = validator.Validate(item);
            if (validationResult.IsValid)
            {

                var res = item.ID != 0 ? await _userRepository.Update(item) : await _userRepository.Create(item);
                var resObj = new ResponseModel()
                {
                    Data = res,
                    ErrorMessage = "",
                    IsError = false,
                    RecordCount = 1
                };
                return resObj;
            }
            else
            {
                var resObj = new ResponseModel()
                {
                    ErrorMessage = validationResult.Errors.FirstOrDefault().ErrorMessage,
                    IsError = true
                };
                return resObj;
            }
        }
    }
}
