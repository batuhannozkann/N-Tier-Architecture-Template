using CV.Core.DTOs.Person;
using CV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Abstract
{
    public interface IPersonService
    {
        ICollection<PersonDto> GetAll();
        Task<PersonDto> GetByIdAsync(long id);
        Task<PersonDto> GetSingleAsync(Expression<Func<Person, bool>> method);
        ICollection<PersonDto> GetWhere(Expression<Func<Person, bool>> method);
        Task<PersonDto> AddAsync(CreatePersonDto model);
        Task<List<PersonDto>> AddRangeAsync(List<CreatePersonDto> model);
        Task Remove(long id);
        void Remove(PersonDto model);
        void RemoveRange(List<PersonDto> datas);
        void Update(PersonDto model);
        Task<int> SaveAsync();
    }
}
