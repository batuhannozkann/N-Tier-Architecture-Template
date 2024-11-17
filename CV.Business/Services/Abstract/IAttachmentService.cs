using CV.Core.DTOs.Attachment;
using CV.Core.Entities;
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
        Task<AttachmentDto> AddAsync(CreateAttachmentDto model);
        Task<List<AttachmentDto>> AddRangeAsync(List<CreateAttachmentDto> model);
        ICollection<AttachmentDto> GetAll();
        Task<AttachmentDto> GetByIdAsync(long id);
        Task<AttachmentDto> GetSingleAsync(Expression<Func<Attachment, bool>> method);
        ICollection<AttachmentDto> GetWhere(Expression<Func<Attachment, bool>> method);
        Task Remove(long id);
        void Remove(AttachmentDto model);
        void RemoveRange(List<AttachmentDto> datas);
        Task<int> SaveAsync();
        void Update(AttachmentDto model);
    }
}
