using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Reference;
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
    public class ReferenceService : IReferenceService
    {
        private readonly IReferenceRepository _referenceRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ReferenceService(IReferenceRepository referenceRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _referenceRepository = referenceRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ReferenceDto>> AddAsync(CreateReferenceDto model)
        {
            Reference reference = _mapper.Map<Reference>(model);
            reference.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _referenceRepository.AddAsync(reference);

            return new ResponseDto<ReferenceDto>
            {
                Data = _mapper.Map<ReferenceDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Reference successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<ReferenceDto>>> AddRangeAsync(List<CreateReferenceDto> model)
        {
            List<Reference> references = _mapper.Map<List<Reference>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                references[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _referenceRepository.AddRangeAsync(references);

            return new ResponseDto<List<ReferenceDto>>
            {
                Data = _mapper.Map<List<ReferenceDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "References successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<ReferenceDto>> GetAll()
        {
            var references = _referenceRepository.GetAll().ToList();
            return new ResponseDto<ICollection<ReferenceDto>>
            {
                Data = _mapper.Map<List<ReferenceDto>>(references),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "References successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<ReferenceDto>> GetByIdAsync(long id)
        {
            var reference = await _referenceRepository.GetByIdAsync(id);
            if (reference == null)
            {
                return new ResponseDto<ReferenceDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Reference not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<ReferenceDto>
            {
                Data = _mapper.Map<ReferenceDto>(reference),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Reference successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<ReferenceDto>> GetSingleAsync(Expression<Func<Reference, bool>> method)
        {
            var reference = await _referenceRepository.GetSingleAsync(method);
            if (reference == null)
            {
                return new ResponseDto<ReferenceDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Reference not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<ReferenceDto>
            {
                Data = _mapper.Map<ReferenceDto>(reference),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Reference successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<ReferenceDto>> GetWhere(Expression<Func<Reference, bool>> method)
        {
            var references = _referenceRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<ReferenceDto>>
            {
                Data = _mapper.Map<List<ReferenceDto>>(references),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "References successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _referenceRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Reference successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(ReferenceDto model)
        {
            _referenceRepository.Remove(_mapper.Map<Reference>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Reference successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<ReferenceDto> datas)
        {
            _referenceRepository.RemoveRange(_mapper.Map<List<Reference>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "References successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _referenceRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(ReferenceDto model)
        {
            _referenceRepository.Update(_mapper.Map<Reference>(model));
            await _referenceRepository.SaveAsync();

            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Reference successfully updated",
                IsSuccess = true
            };
        }
    }
}
