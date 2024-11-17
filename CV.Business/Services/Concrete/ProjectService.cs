using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Project;
using CV.Core.Entities;
using CV.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> AddAsync(CreateProjectDto model)
        {
            Project project = _mapper.Map<Project>(model);
            var result = await _projectRepository.AddAsync(project);
            return _mapper.Map<ProjectDto>(result);
        }

        public async Task<List<ProjectDto>> AddRangeAsync(List<CreateProjectDto> model)
        {
            List<Project> projects = _mapper.Map<List<Project>>(model);
            var result = await _projectRepository.AddRangeAsync(projects);
            return _mapper.Map<List<ProjectDto>>(result);
        }

        public ICollection<ProjectDto> GetAll()
        {
            List<ProjectDto> projects = _mapper.Map<List<ProjectDto>>(_projectRepository.GetAll().ToList());
            return projects;
        }

        public async Task<ProjectDto> GetByIdAsync(long id)
        {
            Project project = await _projectRepository.GetByIdAsync(id);
            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public async Task<ProjectDto> GetSingleAsync(Expression<Func<Project, bool>> method)
        {
            Project project = await _projectRepository.GetSingleAsync(method);
            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public ICollection<ProjectDto> GetWhere(Expression<Func<Project, bool>> method)
        {
            List<Project> projects = _projectRepository.GetWhere(method).ToList();
            List<ProjectDto> projectDtos = _mapper.Map<List<ProjectDto>>(projects);
            return projectDtos;
        }

        public async Task Remove(long id)
        {
            await _projectRepository.Remove(id);
        }

        public void Remove(ProjectDto model)
        {
            _projectRepository.Remove(_mapper.Map<Project>(model));
        }

        public void RemoveRange(List<ProjectDto> datas)
        {
            _projectRepository.RemoveRange(_mapper.Map<List<Project>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectDto model)
        {
            _projectRepository.Update(_mapper.Map<Project>(model));
        }
    }
}
