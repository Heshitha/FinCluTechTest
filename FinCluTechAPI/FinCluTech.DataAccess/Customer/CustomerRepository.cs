using AutoMapper;
using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using FinCluTech.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.DataAccess.Customer
{
    public class CustomerRepository : BaseRepository<Data.Entities.Customer, CustomerBo>, ICustomerRepository
    {
        public async Task<ResponseModel> UploadBulk(List<CustomerBo> lstCustomers)
        {
            using (DataContext context = new DataContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerBo, Data.Entities.Customer>());
                var mapper = config.CreateMapper();
                List<Data.Entities.Customer> ent = mapper.Map<List<Data.Entities.Customer>>(lstCustomers);
                context.Set<Data.Entities.Customer>().AddRange(ent);
                await context.SaveChangesAsync();

                var configReverse = new MapperConfiguration(cfg => cfg.CreateMap<Data.Entities.Customer, CustomerBo>());
                var mapperReverse = configReverse.CreateMapper();
                List<CustomerBo> entReverse = mapperReverse.Map<List<CustomerBo>>(ent);

                var resObj = new ResponseModel()
                {
                    Data = entReverse,
                    ErrorMessage = "",
                    IsError = false,
                    RecordCount = entReverse.Count
                };
                return resObj;
            }
        }
    }
}
