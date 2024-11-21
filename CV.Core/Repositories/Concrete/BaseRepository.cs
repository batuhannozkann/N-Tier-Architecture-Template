using CV.Core.Repositories.Abstract;
using CV.Shared.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.Repositories.Concrete
{
    public class BaseRepository<T, TContext> : IBaseRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll()
        => Table.AsQueryable();
        //AsNoTrackingIdentityResolution 
        public async Task<T> GetByIdAsync(long id)
        => await Table.FindAsync(id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.AsQueryable().Where(method);
        public async Task<T> AddAsync(T model)
        {
            await Table.AddAsync(model);
            return model;
        }

        public async Task<List<T>> AddRangeAsync(List<T> model)

        {
            await Table.AddRangeAsync(model);
            return model;

        }

        public async Task Remove(long id)
        {
            T model = await Table.FindAsync(id);
            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;

        }

        public void Remove(T model)
        {
            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;

        }

        public void RemoveRange(List<T> datas)
        {
            foreach (T data in datas)
            {
                data.IsDeleted = true;
                data.DeletedAt = DateTime.UtcNow;
            }

        }

        public void Update(T model)
        {
            Table.Entry(model).State = EntityState.Modified;


        }
        public async Task<int> SaveAsync()

            => await _context.SaveChangesAsync();

    }

}
