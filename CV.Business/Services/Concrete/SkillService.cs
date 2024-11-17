using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Skill;
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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<SkillDto> AddAsync(CreateSkillDto model)
        {
            Skill skill = _mapper.Map<Skill>(model);
            var result = await _skillRepository.AddAsync(skill);
            return _mapper.Map<SkillDto>(result);
        }

        public async Task<List<SkillDto>> AddRangeAsync(List<CreateSkillDto> model)
        {
            List<Skill> skills = _mapper.Map<List<Skill>>(model);
            var result = await _skillRepository.AddRangeAsync(skills);
            return _mapper.Map<List<SkillDto>>(result);
        }

        public ICollection<SkillDto> GetAll()
        {
            List<SkillDto> skills = _mapper.Map<List<SkillDto>>(_skillRepository.GetAll().ToList());
            return skills;
        }

        public async Task<SkillDto> GetByIdAsync(long id)
        {
            Skill skill = await _skillRepository.GetByIdAsync(id);
            SkillDto skillDto = _mapper.Map<SkillDto>(skill);
            return skillDto;
        }

        public async Task<SkillDto> GetSingleAsync(Expression<Func<Skill, bool>> method)
        {
            Skill skill = await _skillRepository.GetSingleAsync(method);
            SkillDto skillDto = _mapper.Map<SkillDto>(skill);
            return skillDto;
        }

        public ICollection<SkillDto> GetWhere(Expression<Func<Skill, bool>> method)
        {
            List<Skill> skills = _skillRepository.GetWhere(method).ToList();
            List<SkillDto> skillDtos = _mapper.Map<List<SkillDto>>(skills);
            return skillDtos;
        }

        public async Task Remove(long id)
        {
            await _skillRepository.Remove(id);
        }

        public void Remove(SkillDto model)
        {
            _skillRepository.Remove(_mapper.Map<Skill>(model));
        }

        public void RemoveRange(List<SkillDto> datas)
        {
            _skillRepository.RemoveRange(_mapper.Map<List<Skill>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(SkillDto model)
        {
            _skillRepository.Update(_mapper.Map<Skill>(model));
        }
    }
}
