using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Certificate;
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
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CertificateService(ICertificateRepository certificateRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CertificateDto>> AddAsync(CreateCertificateDto model)
        {
            Certificate certificate = _mapper.Map<Certificate>(model);
            certificate.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _certificateRepository.AddAsync(certificate);
            return new ResponseDto<CertificateDto>
            {
                Data = _mapper.Map<CertificateDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Certificate successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<CertificateDto>>> AddRangeAsync(List<CreateCertificateDto> model)
        {
            List<Certificate> certificates = _mapper.Map<List<Certificate>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                certificates[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _certificateRepository.AddRangeAsync(certificates);
            return new ResponseDto<List<CertificateDto>>
            {
                Data = _mapper.Map<List<CertificateDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Certificates successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<CertificateDto>> GetAll()
        {
            var certificates = _mapper.Map<List<CertificateDto>>(_certificateRepository.GetAll().ToList());
            return new ResponseDto<ICollection<CertificateDto>>
            {
                Data = certificates,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificates successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<CertificateDto>> GetByIdAsync(long id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            if (certificate == null)
                return new ResponseDto<CertificateDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Certificate not found",
                    IsSuccess = false
                };

            return new ResponseDto<CertificateDto>
            {
                Data = _mapper.Map<CertificateDto>(certificate),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificate successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<CertificateDto>> GetSingleAsync(Expression<Func<Certificate, bool>> method)
        {
            var certificate = await _certificateRepository.GetSingleAsync(method);
            if (certificate == null)
                return new ResponseDto<CertificateDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Certificate not found",
                    IsSuccess = false
                };

            return new ResponseDto<CertificateDto>
            {
                Data = _mapper.Map<CertificateDto>(certificate),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificate successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<CertificateDto>> GetWhere(Expression<Func<Certificate, bool>> method)
        {
            var certificates = _certificateRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<CertificateDto>>
            {
                Data = _mapper.Map<List<CertificateDto>>(certificates),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificates successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _certificateRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificate successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(CertificateDto model)
        {
            _certificateRepository.Remove(_mapper.Map<Certificate>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificate successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<CertificateDto> datas)
        {
            _certificateRepository.RemoveRange(_mapper.Map<List<Certificate>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificates successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _certificateRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(CertificateDto model)
        {
            _certificateRepository.Update(_mapper.Map<Certificate>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Certificate successfully updated",
                IsSuccess = true
            };
        }
    }
}
