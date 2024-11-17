using CV.Core.DTOs.SocialMedia;
using CV.Core.Entities;
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
        Task<SocialMediaDto> AddAsync(CreateSocialMediaDto model);
        Task<List<SocialMediaDto>> AddRangeAsync(List<CreateSocialMediaDto> model);
        ICollection<SocialMediaDto> GetAll();
        Task<SocialMediaDto> GetByIdAsync(long id);
        Task<SocialMediaDto> GetSingleAsync(Expression<Func<SocialMedia, bool>> method);
        ICollection<SocialMediaDto> GetWhere(Expression<Func<SocialMedia, bool>> method);
        Task Remove(long id);
        void Remove(SocialMediaDto model);
        void RemoveRange(List<SocialMediaDto> datas);
        Task<int> SaveAsync();
        void Update(SocialMediaDto model);
    }


}
