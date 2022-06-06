using AutoMapper;
using FinCluTech.BusinessObject.Models;
using FinCluTech.Data;
using FinCluTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.DataAccess
{
    public class BaseRepository<TEntity, TBO> : IBaseRepository<TEntity, TBO> where TEntity : DomainCommon where TBO : BOCommon
    {
        public async Task<TBO> Create(TBO item)
        {
            using (DataContext context = new DataContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TBO, TEntity>());
                var mapper = config.CreateMapper();
                TEntity ent = mapper.Map<TEntity>(item);
                context.Set<TEntity>().Add(ent);
                await context.SaveChangesAsync();
                item.ID = ent.ID;
                return item;
            }
        }

        public async Task<bool> Delete(int ID)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.ID == ID);
                if (item != null)
                {
                    item.IsDeleted = true;
                }
                return (await context.SaveChangesAsync()) > 0;
            }
        }

        public async Task<TBO> Get(int ID)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.ID == ID);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TBO>());
                var mapper = config.CreateMapper();
                return item != null ? mapper.Map<TBO>(item) : null;
            }
        }

        public async Task<List<TBO>> GetAll()
        {
            using (DataContext context = new DataContext())
            {
                var items = await context.Set<TEntity>().Where(x => !x.IsDeleted).ToListAsync();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TBO>());
                var mapper = config.CreateMapper();
                return items != null ? mapper.Map<List<TBO>>(items) : null;
            }
        }

        public async Task<TBO> Update(TBO item)
        {
            using (DataContext context = new DataContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TBO, TEntity>());
                var mapper = config.CreateMapper();
                TEntity dbitm = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.ID == item.ID);
                TEntity ent = mapper.Map<TEntity>(item);
                dbitm = ent;
                await context.SaveChangesAsync();
                return item;
            }
        }
    }
}
