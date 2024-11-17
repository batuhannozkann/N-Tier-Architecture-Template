using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class PersonRepository : BaseRepository<Person, CvApplicationContext>,IPersonRepository
    {
        public PersonRepository(CvApplicationContext context) : base(context)
        {
        }
    }


}
