using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.Core.Customer
{
    public interface ICustomerManager : IBaseManager<CustomerBo>
    {
        Task<ResponseModel> SaveBulk(List<CustomerBo> full);
    }
}
