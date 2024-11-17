using CV.Core.DTOs.Certificate;
using CV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Abstract
{
    public interface ICertificateService
    {
        Task<CertificateDto> AddAsync(CreateCertificateDto model);
        Task<List<CertificateDto>> AddRangeAsync(List<CreateCertificateDto> model);
        ICollection<CertificateDto> GetAll();
        Task<CertificateDto> GetByIdAsync(long id);
        Task<CertificateDto> GetSingleAsync(Expression<Func<Certificate, bool>> method);
        ICollection<CertificateDto> GetWhere(Expression<Func<Certificate, bool>> method);
        Task Remove(long id);
        void Remove(CertificateDto model);
        void RemoveRange(List<CertificateDto> datas);
        Task<int> SaveAsync();
        void Update(CertificateDto model);
    }
}
