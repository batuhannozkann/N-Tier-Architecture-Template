using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class ProjectRepository : BaseRepository<Project, CvApplicationContext>,IProjectRepository
    {
        public ProjectRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
