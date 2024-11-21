using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Skill;
using CV.Core.Entities;
using CV.DataAccess.Repositories.Abstract;
using CV.DataAccess.Repositories.Concrete;
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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<SkillDto>> AddAsync(CreateSkillDto model)
        {
            Skill skill = _mapper.Map<Skill>(model);
            skill.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _skillRepository.AddAsync(skill);

            return new ResponseDto<SkillDto>
            {
                Data = _mapper.Map<SkillDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Skill successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<SkillDto>>> AddRangeAsync(List<CreateSkillDto> model)
        {
            List<Skill> skills = _mapper.Map<List<Skill>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                skills[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _skillRepository.AddRangeAsync(skills);

            return new ResponseDto<List<SkillDto>>
            {
                Data = _mapper.Map<List<SkillDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Skills successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<SkillDto>> GetAll()
        {
            var skills = _skillRepository.GetAll().ToList();
            return new ResponseDto<ICollection<SkillDto>>
            {
                Data = _mapper.Map<List<SkillDto>>(skills),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skills successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<SkillDto>> GetByIdAsync(long id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return new ResponseDto<SkillDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Skill not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<SkillDto>
            {
                Data = _mapper.Map<SkillDto>(skill),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skill successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<SkillDto>> GetSingleAsync(Expression<Func<Skill, bool>> method)
        {
            var skill = await _skillRepository.GetSingleAsync(method);
            if (skill == null)
            {
                return new ResponseDto<SkillDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Skill not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<SkillDto>
            {
                Data = _mapper.Map<SkillDto>(skill),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skill successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<SkillDto>> GetWhere(Expression<Func<Skill, bool>> method)
        {
            var skills = _skillRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<SkillDto>>
            {
                Data = _mapper.Map<List<SkillDto>>(skills),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skills successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _skillRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skill successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(SkillDto model)
        {
            _skillRepository.Remove(_mapper.Map<Skill>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skill successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<SkillDto> datas)
        {
            _skillRepository.RemoveRange(_mapper.Map<List<Skill>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skills successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _skillRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(SkillDto model)
        {
            _skillRepository.Update(_mapper.Map<Skill>(model));
            await _skillRepository.SaveAsync();

            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Skill successfully updated",
                IsSuccess = true
            };
        }
    }
}
