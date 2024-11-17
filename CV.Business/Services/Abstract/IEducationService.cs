using CV.Core.DTOs.Education;
using CV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Abstract
{
    public interface IEducationService
    {
        Task<EducationDto> AddAsync(CreateEducationDto model);
        Task<List<EducationDto>> AddRangeAsync(List<CreateEducationDto> model);
        ICollection<EducationDto> GetAll();
        Task<EducationDto> GetByIdAsync(long id);
        Task<EducationDto> GetSingleAsync(Expression<Func<Education, bool>> method);
        ICollection<EducationDto> GetWhere(Expression<Func<Education, bool>> method);
        Task Remove(long id);
        void Remove(EducationDto model);
        void RemoveRange(List<EducationDto> datas);
        Task<int> SaveAsync();
        void Update(EducationDto model);
    }
}
