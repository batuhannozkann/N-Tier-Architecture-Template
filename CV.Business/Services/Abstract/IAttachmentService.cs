using CV.Core.DTOs.Attachment;
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
    public interface IAttachmentService
    {
        public interface IAttachmentService
        {
            Task<ResponseDto<AttachmentDto>> AddAsync(CreateAttachmentDto model);
            Task<ResponseDto<List<AttachmentDto>>> AddRangeAsync(List<CreateAttachmentDto> model);
            ResponseDto<ICollection<AttachmentDto>> GetAll();
            Task<ResponseDto<AttachmentDto>> GetByIdAsync(long id);
            Task<ResponseDto<AttachmentDto>> GetSingleAsync(Expression<Func<Attachment, bool>> method);
            ResponseDto<ICollection<AttachmentDto>> GetWhere(Expression<Func<Attachment, bool>> method);
            Task<ResponseDtoWithoutData> Remove(long id);
            ResponseDtoWithoutData Remove(AttachmentDto model);
            ResponseDtoWithoutData RemoveRange(List<AttachmentDto> datas);
            Task<int> SaveAsync();
            Task<ResponseDtoWithoutData> Update(AttachmentDto model);
        }

    }
}
