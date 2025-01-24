using Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Abstract
{
    public interface IBaseRepositoryNoTracking<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        public IQueryable<T> GetAllAsNoTrackingWithIdentityResolution();
        public IQueryable<T> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> method);
    }
}
