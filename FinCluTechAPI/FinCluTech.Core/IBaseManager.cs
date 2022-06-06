using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.Core
{
    public interface IBaseManager<TBo> where TBo : BOCommon
    {
        public Task<ResponseModel> Get(int ID);
        public Task<ResponseModel> GetAll();
        public Task<ResponseModel> Save(TBo item);
        public Task<ResponseModel> Delete(int ID);
    }
}
