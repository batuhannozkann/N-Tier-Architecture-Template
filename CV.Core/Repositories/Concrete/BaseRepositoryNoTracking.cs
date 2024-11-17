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
    public class BaseRepositoryNoTracking<T, TContext> : BaseRepository<T, TContext>, IBaseRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        private TContext _context;
        public BaseRepositoryNoTracking(TContext context) : base(context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAllAsNoTrackingWithIdentityResolution()
        {
            return Table.AsNoTrackingWithIdentityResolution();
        }
        public IQueryable<T> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> method)
        {
            return Table.Where(method).AsNoTrackingWithIdentityResolution();
        }
    }
}
