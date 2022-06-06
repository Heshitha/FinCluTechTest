using FinCluTech.BusinessObject.Models;
using FinCluTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.DataAccess
{
    public interface IBaseRepository<TEntity, TBO> where TEntity : DomainCommon where TBO : BOCommon
    {
        public Task<TBO> Get(int ID);
        public Task<List<TBO>> GetAll();
        public Task<TBO> Create(TBO item);
        public Task<TBO> Update(TBO item);
        public Task<bool> Delete(int ID);
    }
}
