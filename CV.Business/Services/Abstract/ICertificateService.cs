using CV.Core.DTOs.Certificate;
using CV.Core.Entities;
using CV.Shared.DTOs;
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
        Task<ResponseDto<CertificateDto>> AddAsync(CreateCertificateDto model);
        Task<ResponseDto<List<CertificateDto>>> AddRangeAsync(List<CreateCertificateDto> model);
        ResponseDto<ICollection<CertificateDto>> GetAll();
        Task<ResponseDto<CertificateDto>> GetByIdAsync(long id);
        Task<ResponseDto<CertificateDto>> GetSingleAsync(Expression<Func<Certificate, bool>> method);
        ResponseDto<ICollection<CertificateDto>> GetWhere(Expression<Func<Certificate, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(CertificateDto model);
        ResponseDtoWithoutData RemoveRange(List<CertificateDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(CertificateDto model);
    }
}
