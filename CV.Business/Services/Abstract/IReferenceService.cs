using CV.Core.DTOs.Reference;
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
    public interface IReferenceService
    {
        Task<ResponseDto<ReferenceDto>> AddAsync(CreateReferenceDto model);
        Task<ResponseDto<List<ReferenceDto>>> AddRangeAsync(List<CreateReferenceDto> model);
        ResponseDto<ICollection<ReferenceDto>> GetAll();
        Task<ResponseDto<ReferenceDto>> GetByIdAsync(long id);
        Task<ResponseDto<ReferenceDto>> GetSingleAsync(Expression<Func<Reference, bool>> method);
        ResponseDto<ICollection<ReferenceDto>> GetWhere(Expression<Func<Reference, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(ReferenceDto model);
        ResponseDtoWithoutData RemoveRange(List<ReferenceDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(ReferenceDto model);
    }
}
