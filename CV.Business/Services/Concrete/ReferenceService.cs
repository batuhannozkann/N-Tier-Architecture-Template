using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Reference;
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
    public class ReferenceService : IReferenceService
    {
        private readonly IReferenceRepository _referenceRepository;
        private readonly IMapper _mapper;

        public ReferenceService(IReferenceRepository referenceRepository, IMapper mapper)
        {
            _referenceRepository = referenceRepository;
            _mapper = mapper;
        }

        public async Task<ReferenceDto> AddAsync(CreateReferenceDto model)
        {
            Reference reference = _mapper.Map<Reference>(model);
            var result = await _referenceRepository.AddAsync(reference);
            return _mapper.Map<ReferenceDto>(result);
        }

        public async Task<List<ReferenceDto>> AddRangeAsync(List<CreateReferenceDto> model)
        {
            List<Reference> references = _mapper.Map<List<Reference>>(model);
            var result = await _referenceRepository.AddRangeAsync(references);
            return _mapper.Map<List<ReferenceDto>>(result);
        }

        public ICollection<ReferenceDto> GetAll()
        {
            List<ReferenceDto> references = _mapper.Map<List<ReferenceDto>>(_referenceRepository.GetAll().ToList());
            return references;
        }

        public async Task<ReferenceDto> GetByIdAsync(long id)
        {
            Reference reference = await _referenceRepository.GetByIdAsync(id);
            ReferenceDto referenceDto = _mapper.Map<ReferenceDto>(reference);
            return referenceDto;
        }

        public async Task<ReferenceDto> GetSingleAsync(Expression<Func<Reference, bool>> method)
        {
            Reference reference = await _referenceRepository.GetSingleAsync(method);
            ReferenceDto referenceDto = _mapper.Map<ReferenceDto>(reference);
            return referenceDto;
        }

        public ICollection<ReferenceDto> GetWhere(Expression<Func<Reference, bool>> method)
        {
            List<Reference> references = _referenceRepository.GetWhere(method).ToList();
            List<ReferenceDto> referenceDtos = _mapper.Map<List<ReferenceDto>>(references);
            return referenceDtos;
        }

        public async Task Remove(long id)
        {
            await _referenceRepository.Remove(id);
        }

        public void Remove(ReferenceDto model)
        {
            _referenceRepository.Remove(_mapper.Map<Reference>(model));
        }

        public void RemoveRange(List<ReferenceDto> datas)
        {
            _referenceRepository.RemoveRange(_mapper.Map<List<Reference>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(ReferenceDto model)
        {
            _referenceRepository.Update(_mapper.Map<Reference>(model));
        }
    }
}
