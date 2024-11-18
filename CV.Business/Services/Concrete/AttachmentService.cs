using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Attachment;
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
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentRepository attachmentRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<AttachmentDto>> AddAsync(CreateAttachmentDto model)
        {
            Attachment attachment = _mapper.Map<Attachment>(model);
            attachment.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _attachmentRepository.AddAsync(attachment);
            return new ResponseDto<AttachmentDto>
            {
                Data = _mapper.Map<AttachmentDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Attachment successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<AttachmentDto>>> AddRangeAsync(List<CreateAttachmentDto> model)
        {
            List<Attachment> attachments = _mapper.Map<List<Attachment>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                attachments[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _attachmentRepository.AddRangeAsync(attachments);
            return new ResponseDto<List<AttachmentDto>>
            {
                Data = _mapper.Map<List<AttachmentDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Attachments successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<AttachmentDto>> GetAll()
        {
            var attachments = _mapper.Map<List<AttachmentDto>>(_attachmentRepository.GetAll().ToList());
            return new ResponseDto<ICollection<AttachmentDto>>
            {
                Data = attachments,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachments successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<AttachmentDto>> GetByIdAsync(long id)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(id);
            if (attachment == null)
                return new ResponseDto<AttachmentDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Attachment not found",
                    IsSuccess = false
                };

            return new ResponseDto<AttachmentDto>
            {
                Data = _mapper.Map<AttachmentDto>(attachment),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachment successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<AttachmentDto>> GetSingleAsync(Expression<Func<Attachment, bool>> method)
        {
            var attachment = await _attachmentRepository.GetSingleAsync(method);
            if (attachment == null)
                return new ResponseDto<AttachmentDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Attachment not found",
                    IsSuccess = false
                };

            return new ResponseDto<AttachmentDto>
            {
                Data = _mapper.Map<AttachmentDto>(attachment),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachment successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<AttachmentDto>> GetWhere(Expression<Func<Attachment, bool>> method)
        {
            var attachments = _attachmentRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<AttachmentDto>>
            {
                Data = _mapper.Map<List<AttachmentDto>>(attachments),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachments successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _attachmentRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachment successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(AttachmentDto model)
        {
            _attachmentRepository.Remove(_mapper.Map<Attachment>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachment successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<AttachmentDto> datas)
        {
            _attachmentRepository.RemoveRange(_mapper.Map<List<Attachment>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachments successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _attachmentRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(AttachmentDto model)
        {
            _attachmentRepository.Update(_mapper.Map<Attachment>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Attachment successfully updated",
                IsSuccess = true
            };
        }
    }
}
