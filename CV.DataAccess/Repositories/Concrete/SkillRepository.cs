using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class SkillRepository : BaseRepository<Skill, CvApplicationContext>,ISkillRepository
    {
        public SkillRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
