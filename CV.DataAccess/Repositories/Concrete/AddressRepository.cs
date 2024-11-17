using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.DataAccess.Repositories.Concrete
{
    public class AddressRepository : BaseRepository<Address, CvApplicationContext>,IAddressRepository
    {
        public AddressRepository(CvApplicationContext context) : base(context)
        {
        }
    }

}
