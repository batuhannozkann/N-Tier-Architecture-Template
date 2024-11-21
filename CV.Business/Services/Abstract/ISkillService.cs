using CV.Core.DTOs.Skill;
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
    public interface ISkillService
    {
        Task<ResponseDto<SkillDto>> AddAsync(CreateSkillDto model);
        Task<ResponseDto<List<SkillDto>>> AddRangeAsync(List<CreateSkillDto> model);
        ResponseDto<ICollection<SkillDto>> GetAll();
        Task<ResponseDto<SkillDto>> GetByIdAsync(long id);
        Task<ResponseDto<SkillDto>> GetSingleAsync(Expression<Func<Skill, bool>> method);
        ResponseDto<ICollection<SkillDto>> GetWhere(Expression<Func<Skill, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(SkillDto model);
        ResponseDtoWithoutData RemoveRange(List<SkillDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(SkillDto model);
    }


}
