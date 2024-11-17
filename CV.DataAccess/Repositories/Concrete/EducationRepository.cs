using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class EducationRepository : BaseRepository<Education, CvApplicationContext>,IEducationRepository
    {
        public EducationRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
