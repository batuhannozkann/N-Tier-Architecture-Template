using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class AttachmentRepository : BaseRepository<Attachment, CvApplicationContext>,IAttachmentRepository
    {
        public AttachmentRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
