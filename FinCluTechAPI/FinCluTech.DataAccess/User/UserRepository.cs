using AutoMapper;
using FinCluTech.BusinessObject.Models;
using FinCluTech.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.DataAccess.User
{
    public class UserRepository : BaseRepository<Data.Entities.User, UserBo>, IUserRepository
    {
        public async Task<UserBo> AuthenticateUser(string userName, string password)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Trim() == userName.ToLower().Trim() && x.Password == password);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Data.Entities.User, UserBo>());
                var mapper = config.CreateMapper();
                return item != null ? mapper.Map<UserBo>(item) : null;
            }
        }
    }
}
