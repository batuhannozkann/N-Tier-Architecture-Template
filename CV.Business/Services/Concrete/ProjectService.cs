using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Project;
using CV.Core.Entities;
using CV.DataAccess.Repositories.Abstract;
using CV.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectDto>> AddAsync(CreateProjectDto model)
        {
            Project project = _mapper.Map<Project>(model);
            project.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _projectRepository.AddAsync(project);

            return new ResponseDto<ProjectDto>
            {
                Data = _mapper.Map<ProjectDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Project successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<ProjectDto>>> AddRangeAsync(List<CreateProjectDto> model)
        {
            List<Project> projects = _mapper.Map<List<Project>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                projects[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _projectRepository.AddRangeAsync(projects);

            return new ResponseDto<List<ProjectDto>>
            {
                Data = _mapper.Map<List<ProjectDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Projects successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<ProjectDto>> GetAll()
        {
            var projects = _projectRepository.GetAll().ToList();
            return new ResponseDto<ICollection<ProjectDto>>
            {
                Data = _mapper.Map<List<ProjectDto>>(projects),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Projects successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<ProjectDto>> GetByIdAsync(long id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return new ResponseDto<ProjectDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Project not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<ProjectDto>
            {
                Data = _mapper.Map<ProjectDto>(project),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Project successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<ProjectDto>> GetSingleAsync(Expression<Func<Project, bool>> method)
        {
            var project = await _projectRepository.GetSingleAsync(method);
            if (project == null)
            {
                return new ResponseDto<ProjectDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Project not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<ProjectDto>
            {
                Data = _mapper.Map<ProjectDto>(project),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Project successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<ProjectDto>> GetWhere(Expression<Func<Project, bool>> method)
        {
            var projects = _projectRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<ProjectDto>>
            {
                Data = _mapper.Map<List<ProjectDto>>(projects),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Projects successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _projectRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Project successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(ProjectDto model)
        {
            _projectRepository.Remove(_mapper.Map<Project>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Project successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<ProjectDto> datas)
        {
            _projectRepository.RemoveRange(_mapper.Map<List<Project>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Projects successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _projectRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(ProjectDto model)
        {
            _projectRepository.Update(_mapper.Map<Project>(model));
            await _projectRepository.SaveAsync();

            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Project successfully updated",
                IsSuccess = true
            };
        }
    }
}
