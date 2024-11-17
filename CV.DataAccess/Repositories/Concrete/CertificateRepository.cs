using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class CertificateRepository : BaseRepository<Certificate, CvApplicationContext>,ICertificateRepository
    {
        public CertificateRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
