using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Infra.Context;

namespace Prova.MarQ.Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        protected readonly ProvaMarQContext _Db;

        public RepositoryBase(ProvaMarQContext context)
        {
            _Db = context;
        }

        public async Task AddAsync(TEntity obj)
        {
            _Db.Set<TEntity>().Add(obj);
            await _Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _Db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _Db.Set<TEntity>().FindAsync(id);
        }

        public async Task SoftDeleteAsync(TEntity obj)
        {
            var property = obj.GetType().GetProperty("IsDeleted");
            if (property != null)
            {
                property.SetValue(obj, true);
                _Db.Set<TEntity>().Update(obj);
                await _Db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            await _Db.SaveChangesAsync();
        }
    }
}
