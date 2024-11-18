using CV.Core.DTOs.Person;
using CV.Core.Entities;
using CV.Shared.DTOs;
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
        ResponseDto<ICollection<PersonDto>> GetAll();
        Task<ResponseDto<PersonDto>> GetByIdAsync(long id);
        Task<ResponseDto<PersonDto>> GetSingleAsync(Expression<Func<Person, bool>> method);
        ResponseDto<ICollection<PersonDto>> GetWhere(Expression<Func<Person, bool>> method);
        Task<ResponseDto<PersonDto>> AddAsync(CreatePersonDto model);
        Task<ResponseDto<List<PersonDto>>> AddRangeAsync(List<CreatePersonDto> model);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(PersonDto model);
        ResponseDtoWithoutData RemoveRange(List<PersonDto> datas);
        Task<ResponseDtoWithoutData> Update(PersonDto model);
        Task<int> SaveAsync();
    }

}
