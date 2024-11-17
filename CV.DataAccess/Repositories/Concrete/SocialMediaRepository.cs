using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class SocialMediaRepository : BaseRepository<SocialMedia, CvApplicationContext>,ISocialMediaRepository
    {
        public SocialMediaRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
