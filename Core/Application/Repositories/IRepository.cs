using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }

        IQueryable<TEntity> GetAll(bool tracking = true);

        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetByIdAsync(long id, bool tracking = true);


        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> datas);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        bool RemoveRange(List<TEntity> datas);
        Task<bool> RemoveByIdAsync(long id);     

        Task<int> SaveChangesAsync();

    }
}
