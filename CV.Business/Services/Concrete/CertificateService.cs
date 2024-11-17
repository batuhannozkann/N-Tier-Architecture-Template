using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Certificate;
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
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public CertificateService(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<CertificateDto> AddAsync(CreateCertificateDto model)
        {
            Certificate certificate = _mapper.Map<Certificate>(model);
            var result = await _certificateRepository.AddAsync(certificate);
            return _mapper.Map<CertificateDto>(result);
        }

        public async Task<List<CertificateDto>> AddRangeAsync(List<CreateCertificateDto> model)
        {
            List<Certificate> certificates = _mapper.Map<List<Certificate>>(model);
            var result = await _certificateRepository.AddRangeAsync(certificates);
            return _mapper.Map<List<CertificateDto>>(result);
        }

        public ICollection<CertificateDto> GetAll()
        {
            List<CertificateDto> certificates = _mapper.Map<List<CertificateDto>>(_certificateRepository.GetAll().ToList());
            return certificates;
        }

        public async Task<CertificateDto> GetByIdAsync(long id)
        {
            Certificate certificate = await _certificateRepository.GetByIdAsync(id);
            CertificateDto certificateDto = _mapper.Map<CertificateDto>(certificate);
            return certificateDto;
        }

        public async Task<CertificateDto> GetSingleAsync(Expression<Func<Certificate, bool>> method)
        {
            Certificate certificate = await _certificateRepository.GetSingleAsync(method);
            CertificateDto certificateDto = _mapper.Map<CertificateDto>(certificate);
            return certificateDto;
        }

        public ICollection<CertificateDto> GetWhere(Expression<Func<Certificate, bool>> method)
        {
            List<Certificate> certificates = _certificateRepository.GetWhere(method).ToList();
            List<CertificateDto> certificateDtos = _mapper.Map<List<CertificateDto>>(certificates);
            return certificateDtos;
        }

        public async Task Remove(long id)
        {
            await _certificateRepository.Remove(id);
        }

        public void Remove(CertificateDto model)
        {
            _certificateRepository.Remove(_mapper.Map<Certificate>(model));
        }

        public void RemoveRange(List<CertificateDto> datas)
        {
            _certificateRepository.RemoveRange(_mapper.Map<List<Certificate>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CertificateDto model)
        {
            _certificateRepository.Update(_mapper.Map<Certificate>(model));
        }
    }
}
