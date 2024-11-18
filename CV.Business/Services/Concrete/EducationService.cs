using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Education;
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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<EducationDto>> AddAsync(CreateEducationDto model)
        {
            Education education = _mapper.Map<Education>(model);
            education.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _educationRepository.AddAsync(education);
            return new ResponseDto<EducationDto>
            {
                Data = _mapper.Map<EducationDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Education successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<EducationDto>>> AddRangeAsync(List<CreateEducationDto> model)
        {
            List<Education> educations = _mapper.Map<List<Education>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                educations[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _educationRepository.AddRangeAsync(educations);
            return new ResponseDto<List<EducationDto>>
            {
                Data = _mapper.Map<List<EducationDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Education records successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<EducationDto>> GetAll()
        {
            var educations = _mapper.Map<List<EducationDto>>(_educationRepository.GetAll().ToList());
            return new ResponseDto<ICollection<EducationDto>>
            {
                Data = educations,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education records successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<EducationDto>> GetByIdAsync(long id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            if (education == null)
                return new ResponseDto<EducationDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Education record not found",
                    IsSuccess = false
                };

            return new ResponseDto<EducationDto>
            {
                Data = _mapper.Map<EducationDto>(education),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education record successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<EducationDto>> GetSingleAsync(Expression<Func<Education, bool>> method)
        {
            var education = await _educationRepository.GetSingleAsync(method);
            if (education == null)
                return new ResponseDto<EducationDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Education record not found",
                    IsSuccess = false
                };

            return new ResponseDto<EducationDto>
            {
                Data = _mapper.Map<EducationDto>(education),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education record successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<EducationDto>> GetWhere(Expression<Func<Education, bool>> method)
        {
            var educations = _educationRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<EducationDto>>
            {
                Data = _mapper.Map<List<EducationDto>>(educations),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education records successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _educationRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education record successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(EducationDto model)
        {
            _educationRepository.Remove(_mapper.Map<Education>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education record successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<EducationDto> datas)
        {
            _educationRepository.RemoveRange(_mapper.Map<List<Education>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education records successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _educationRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(EducationDto model)
        {
            _educationRepository.Update(_mapper.Map<Education>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Education record successfully updated",
                IsSuccess = true
            };
        }
    }
}
