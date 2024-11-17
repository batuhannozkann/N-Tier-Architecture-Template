using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Education;
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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<EducationDto> AddAsync(CreateEducationDto model)
        {
            Education education = _mapper.Map<Education>(model);
            var result = await _educationRepository.AddAsync(education);
            return _mapper.Map<EducationDto>(result);
        }

        public async Task<List<EducationDto>> AddRangeAsync(List<CreateEducationDto> model)
        {
            List<Education> educations = _mapper.Map<List<Education>>(model);
            var result = await _educationRepository.AddRangeAsync(educations);
            return _mapper.Map<List<EducationDto>>(result);
        }

        public ICollection<EducationDto> GetAll()
        {
            List<EducationDto> educations = _mapper.Map<List<EducationDto>>(_educationRepository.GetAll().ToList());
            return educations;
        }

        public async Task<EducationDto> GetByIdAsync(long id)
        {
            Education education = await _educationRepository.GetByIdAsync(id);
            EducationDto educationDto = _mapper.Map<EducationDto>(education);
            return educationDto;
        }

        public async Task<EducationDto> GetSingleAsync(Expression<Func<Education, bool>> method)
        {
            Education education = await _educationRepository.GetSingleAsync(method);
            EducationDto educationDto = _mapper.Map<EducationDto>(education);
            return educationDto;
        }

        public ICollection<EducationDto> GetWhere(Expression<Func<Education, bool>> method)
        {
            List<Education> educations = _educationRepository.GetWhere(method).ToList();
            List<EducationDto> educationDtos = _mapper.Map<List<EducationDto>>(educations);
            return educationDtos;
        }

        public async Task Remove(long id)
        {
            await _educationRepository.Remove(id);
        }

        public void Remove(EducationDto model)
        {
            _educationRepository.Remove(_mapper.Map<Education>(model));
        }

        public void RemoveRange(List<EducationDto> datas)
        {
            _educationRepository.RemoveRange(_mapper.Map<List<Education>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(EducationDto model)
        {
            _educationRepository.Update(_mapper.Map<Education>(model));
        }
    }
}
