using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Attachment;
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
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public async Task<AttachmentDto> AddAsync(CreateAttachmentDto model)
        {
            Attachment attachment = _mapper.Map<Attachment>(model);
            var result = await _attachmentRepository.AddAsync(attachment);
            return _mapper.Map<AttachmentDto>(result);
        }

        public async Task<List<AttachmentDto>> AddRangeAsync(List<CreateAttachmentDto> model)
        {
            List<Attachment> attachments = _mapper.Map<List<Attachment>>(model);
            var result = await _attachmentRepository.AddRangeAsync(attachments);
            return _mapper.Map<List<AttachmentDto>>(result);
        }

        public ICollection<AttachmentDto> GetAll()
        {
            List<AttachmentDto> attachments = _mapper.Map<List<AttachmentDto>>(_attachmentRepository.GetAll().ToList());
            return attachments;
        }

        public async Task<AttachmentDto> GetByIdAsync(long id)
        {
            Attachment attachment = await _attachmentRepository.GetByIdAsync(id);
            AttachmentDto attachmentDto = _mapper.Map<AttachmentDto>(attachment);
            return attachmentDto;
        }

        public async Task<AttachmentDto> GetSingleAsync(Expression<Func<Attachment, bool>> method)
        {
            Attachment attachment = await _attachmentRepository.GetSingleAsync(method);
            AttachmentDto attachmentDto = _mapper.Map<AttachmentDto>(attachment);
            return attachmentDto;
        }

        public ICollection<AttachmentDto> GetWhere(Expression<Func<Attachment, bool>> method)
        {
            List<Attachment> attachments = _attachmentRepository.GetWhere(method).ToList();
            List<AttachmentDto> attachmentDtos = _mapper.Map<List<AttachmentDto>>(attachments);
            return attachmentDtos;
        }

        public async Task Remove(long id)
        {
            await _attachmentRepository.Remove(id);
        }

        public void Remove(AttachmentDto model)
        {
            _attachmentRepository.Remove(_mapper.Map<Attachment>(model));
        }

        public void RemoveRange(List<AttachmentDto> datas)
        {
            _attachmentRepository.RemoveRange(_mapper.Map<List<Attachment>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(AttachmentDto model)
        {
            _attachmentRepository.Update(_mapper.Map<Attachment>(model));
        }
    }
}
