using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.DataAccess.Customer
{
    public interface ICustomerRepository : IBaseRepository<Data.Entities.Customer, CustomerBo>
    {
        public Task<ResponseModel> UploadBulk(List<CustomerBo> lstCustomers);
    }
}
