using CV.Core.DTOs.Project;
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
    public interface IProjectService
    {
        Task<ResponseDto<ProjectDto>> AddAsync(CreateProjectDto model);
        Task<ResponseDto<List<ProjectDto>>> AddRangeAsync(List<CreateProjectDto> model);
        ResponseDto<ICollection<ProjectDto>> GetAll();
        Task<ResponseDto<ProjectDto>> GetByIdAsync(long id);
        Task<ResponseDto<ProjectDto>> GetSingleAsync(Expression<Func<Project, bool>> method);
        ResponseDto<ICollection<ProjectDto>> GetWhere(Expression<Func<Project, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(ProjectDto model);
        ResponseDtoWithoutData RemoveRange(List<ProjectDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(ProjectDto model);
    }

}
