using CV.Core.DTOs.Address;
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
    public interface IAddressService
    {
        Task<ResponseDto<AddressDto>> AddAsync(CreateAddressDto model);
        Task<ResponseDto<List<AddressDto>>> AddRangeAsync(List<CreateAddressDto> model);
        ResponseDto<ICollection<AddressDto>> GetAll();
        Task<ResponseDto<AddressDto>> GetByIdAsync(long id);
        Task<ResponseDto<AddressDto>> GetSingleAsync(Expression<Func<Address, bool>> method);
        ResponseDto<ICollection<AddressDto>> GetWhere(Expression<Func<Address, bool>> method);
        Task<ResponseDtoWithoutData> Remove(long id);
        ResponseDtoWithoutData Remove(AddressDto model);
        ResponseDtoWithoutData RemoveRange(List<AddressDto> datas);
        Task<int> SaveAsync();
        Task<ResponseDtoWithoutData> Update(AddressDto model);
    }
}
