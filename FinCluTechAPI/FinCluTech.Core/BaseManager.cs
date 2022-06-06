using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.Core
{
    public abstract class BaseManager<TBo> where TBo : BOCommon
    {
        public abstract Task<ResponseModel> Delete(int ID);
        public abstract Task<ResponseModel> Get(int ID);
        public abstract Task<ResponseModel> GetAll();
        public abstract Task<ResponseModel> Save(TBo item);
    }
}
