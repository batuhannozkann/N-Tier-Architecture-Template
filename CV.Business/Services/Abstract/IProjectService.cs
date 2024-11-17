using CV.Core.DTOs.Project;
using CV.Core.Entities;
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
        Task<ProjectDto> AddAsync(CreateProjectDto model);
        Task<List<ProjectDto>> AddRangeAsync(List<CreateProjectDto> model);
        ICollection<ProjectDto> GetAll();
        Task<ProjectDto> GetByIdAsync(long id);
        Task<ProjectDto> GetSingleAsync(Expression<Func<Project, bool>> method);
        ICollection<ProjectDto> GetWhere(Expression<Func<Project, bool>> method);
        Task Remove(long id);
        void Remove(ProjectDto model);
        void RemoveRange(List<ProjectDto> datas);
        Task<int> SaveAsync();
        void Update(ProjectDto model);
    }
}
