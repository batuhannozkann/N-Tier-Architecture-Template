using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.SocialMedia;
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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<SocialMediaDto>> AddAsync(CreateSocialMediaDto model)
        {
            SocialMedia socialMedia = _mapper.Map<SocialMedia>(model);
            socialMedia.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _socialMediaRepository.AddAsync(socialMedia);

            return new ResponseDto<SocialMediaDto>
            {
                Data = _mapper.Map<SocialMediaDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Social media account successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<SocialMediaDto>>> AddRangeAsync(List<CreateSocialMediaDto> model)
        {
            List<SocialMedia> socialMedias = _mapper.Map<List<SocialMedia>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                socialMedias[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _socialMediaRepository.AddRangeAsync(socialMedias);

            return new ResponseDto<List<SocialMediaDto>>
            {
                Data = _mapper.Map<List<SocialMediaDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Social media accounts successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<SocialMediaDto>> GetAll()
        {
            var socialMedias = _socialMediaRepository.GetAll().ToList();
            return new ResponseDto<ICollection<SocialMediaDto>>
            {
                Data = _mapper.Map<List<SocialMediaDto>>(socialMedias),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media accounts successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<SocialMediaDto>> GetByIdAsync(long id)
        {
            var socialMedia = await _socialMediaRepository.GetByIdAsync(id);
            if (socialMedia == null)
            {
                return new ResponseDto<SocialMediaDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Social media account not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<SocialMediaDto>
            {
                Data = _mapper.Map<SocialMediaDto>(socialMedia),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media account successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<SocialMediaDto>> GetSingleAsync(Expression<Func<SocialMedia, bool>> method)
        {
            var socialMedia = await _socialMediaRepository.GetSingleAsync(method);
            if (socialMedia == null)
            {
                return new ResponseDto<SocialMediaDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Social media account not found",
                    IsSuccess = false
                };
            }

            return new ResponseDto<SocialMediaDto>
            {
                Data = _mapper.Map<SocialMediaDto>(socialMedia),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media account successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<SocialMediaDto>> GetWhere(Expression<Func<SocialMedia, bool>> method)
        {
            var socialMedias = _socialMediaRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<SocialMediaDto>>
            {
                Data = _mapper.Map<List<SocialMediaDto>>(socialMedias),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media accounts successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _socialMediaRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media account successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(SocialMediaDto model)
        {
            _socialMediaRepository.Remove(_mapper.Map<SocialMedia>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media account successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<SocialMediaDto> datas)
        {
            _socialMediaRepository.RemoveRange(_mapper.Map<List<SocialMedia>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media accounts successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _socialMediaRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(SocialMediaDto model)
        {
            _socialMediaRepository.Update(_mapper.Map<SocialMedia>(model));
            await _socialMediaRepository.SaveAsync();

            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Social media account successfully updated",
                IsSuccess = true
            };
        }
    }
}
