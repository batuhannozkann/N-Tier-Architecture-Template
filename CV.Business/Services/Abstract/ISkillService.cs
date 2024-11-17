using CV.Core.DTOs.Skill;
using CV.Core.Entities;
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
        Task<SkillDto> AddAsync(CreateSkillDto model);
        Task<List<SkillDto>> AddRangeAsync(List<CreateSkillDto> model);
        ICollection<SkillDto> GetAll();
        Task<SkillDto> GetByIdAsync(long id);
        Task<SkillDto> GetSingleAsync(Expression<Func<Skill, bool>> method);
        ICollection<SkillDto> GetWhere(Expression<Func<Skill, bool>> method);
        Task Remove(long id);
        void Remove(SkillDto model);
        void RemoveRange(List<SkillDto> datas);
        Task<int> SaveAsync();
        void Update(SkillDto model);
    }

}
