using CV.Core.DTOs.Address;
using CV.Core.Entities;
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
        Task<AddressDto> AddAsync(CreateAddressDto model);
        Task<List<AddressDto>> AddRangeAsync(List<CreateAddressDto> model);
        ICollection<AddressDto> GetAll();
        Task<AddressDto> GetByIdAsync(long id);
        Task<AddressDto> GetSingleAsync(Expression<Func<Address, bool>> method);
        ICollection<AddressDto> GetWhere(Expression<Func<Address, bool>> method);
        Task Remove(long id);
        void Remove(AddressDto model);
        void RemoveRange(List<AddressDto> datas);
        Task<int> SaveAsync();
        void Update(AddressDto model);
    }
}
