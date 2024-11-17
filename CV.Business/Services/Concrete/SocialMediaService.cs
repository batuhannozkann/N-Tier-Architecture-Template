using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.SocialMedia;
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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }

        public async Task<SocialMediaDto> AddAsync(CreateSocialMediaDto model)
        {
            SocialMedia socialMedia = _mapper.Map<SocialMedia>(model);
            var result = await _socialMediaRepository.AddAsync(socialMedia);
            return _mapper.Map<SocialMediaDto>(result);
        }

        public async Task<List<SocialMediaDto>> AddRangeAsync(List<CreateSocialMediaDto> model)
        {
            List<SocialMedia> socialMedias = _mapper.Map<List<SocialMedia>>(model);
            var result = await _socialMediaRepository.AddRangeAsync(socialMedias);
            return _mapper.Map<List<SocialMediaDto>>(result);
        }

        public ICollection<SocialMediaDto> GetAll()
        {
            List<SocialMediaDto> socialMedias = _mapper.Map<List<SocialMediaDto>>(_socialMediaRepository.GetAll().ToList());
            return socialMedias;
        }

        public async Task<SocialMediaDto> GetByIdAsync(long id)
        {
            SocialMedia socialMedia = await _socialMediaRepository.GetByIdAsync(id);
            SocialMediaDto socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            return socialMediaDto;
        }

        public async Task<SocialMediaDto> GetSingleAsync(Expression<Func<SocialMedia, bool>> method)
        {
            SocialMedia socialMedia = await _socialMediaRepository.GetSingleAsync(method);
            SocialMediaDto socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            return socialMediaDto;
        }

        public ICollection<SocialMediaDto> GetWhere(Expression<Func<SocialMedia, bool>> method)
        {
            List<SocialMedia> socialMedias = _socialMediaRepository.GetWhere(method).ToList();
            List<SocialMediaDto> socialMediaDtos = _mapper.Map<List<SocialMediaDto>>(socialMedias);
            return socialMediaDtos;
        }

        public async Task Remove(long id)
        {
            await _socialMediaRepository.Remove(id);
        }

        public void Remove(SocialMediaDto model)
        {
            _socialMediaRepository.Remove(_mapper.Map<SocialMedia>(model));
        }

        public void RemoveRange(List<SocialMediaDto> datas)
        {
            _socialMediaRepository.RemoveRange(_mapper.Map<List<SocialMedia>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(SocialMediaDto model)
        {
            _socialMediaRepository.Update(_mapper.Map<SocialMedia>(model));
        }
    }
}
