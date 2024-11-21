using CV.Core.DTOs.Education;
using CV.Core.Entities;
using CV.Shared.DTOs;
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
        Task<ResponseDto<EducationDto>> AddAsync(CreateEducationDto model);
        Task<ResponseDto<List<EducationDto>>> AddRangeAsync(List<CreateEducationDto> model);
        ResponseDto<ICollection<EducationDto>> GetAll();
        Task<ResponseDto<EducationDto>> GetByIdAsync(long id);
        Task<ResponseDto<EducationDto>> GetSingleAsync(Expression<Func<Education, bool>> method);
        ResponseDto<ICollection<EducationDto>> GetWhere(Expression<Func<Education, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(EducationDto model);
        ResponseDtoWithoutData RemoveRange(List<EducationDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(EducationDto model);
    }
}
