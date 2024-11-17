using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class ReferenceRepository : BaseRepository<Reference, CvApplicationContext>,IReferenceRepository
    {
        public ReferenceRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
