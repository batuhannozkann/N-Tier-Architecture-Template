using CV.Core.DTOs.Reference;
using CV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Abstract
{
    public interface IReferenceService
    {
        Task<ReferenceDto> AddAsync(CreateReferenceDto model);
        Task<List<ReferenceDto>> AddRangeAsync(List<CreateReferenceDto> model);
        ICollection<ReferenceDto> GetAll();
        Task<ReferenceDto> GetByIdAsync(long id);
        Task<ReferenceDto> GetSingleAsync(Expression<Func<Reference, bool>> method);
        ICollection<ReferenceDto> GetWhere(Expression<Func<Reference, bool>> method);
        Task Remove(long id);
        void Remove(ReferenceDto model);
        void RemoveRange(List<ReferenceDto> datas);
        Task<int> SaveAsync();
        void Update(ReferenceDto model);
    }
}
