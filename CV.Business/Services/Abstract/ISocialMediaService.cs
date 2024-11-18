using CV.Core.DTOs.SocialMedia;
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
    public interface ISocialMediaService
    {
        Task<ResponseDto<SocialMediaDto>> AddAsync(CreateSocialMediaDto model);
        Task<ResponseDto<List<SocialMediaDto>>> AddRangeAsync(List<CreateSocialMediaDto> model);
        ResponseDto<ICollection<SocialMediaDto>> GetAll();
        Task<ResponseDto<SocialMediaDto>> GetByIdAsync(long id);
        Task<ResponseDto<SocialMediaDto>> GetSingleAsync(Expression<Func<SocialMedia, bool>> method);
        ResponseDto<ICollection<SocialMediaDto>> GetWhere(Expression<Func<SocialMedia, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(SocialMediaDto model);
        ResponseDtoWithoutData RemoveRange(List<SocialMediaDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(SocialMediaDto model);
    }


}
