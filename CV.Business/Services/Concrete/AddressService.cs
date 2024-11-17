using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Address;
using CV.Core.Entities;
using CV.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Services.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<AddressDto> AddAsync(CreateAddressDto model)
        {
            Address address = _mapper.Map<Address>(model);
            address.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _addressRepository.AddAsync(address);
            return _mapper.Map<AddressDto>(result);
        }

        public async Task<List<AddressDto>> AddRangeAsync(List<CreateAddressDto> model)
        {
            List<Address> addresses = _mapper.Map<List<Address>>(model);
            var result = await _addressRepository.AddRangeAsync(addresses);
            return _mapper.Map<List<AddressDto>>(result);
        }

        public ICollection<AddressDto> GetAll()
        {
            List<AddressDto> addresses = _mapper.Map<List<AddressDto>>(_addressRepository.GetAll().ToList());
            return addresses;
        }

        public async Task<AddressDto> GetByIdAsync(long id)
        {
            Address address = await _addressRepository.GetByIdAsync(id);
            AddressDto addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }

        public async Task<AddressDto> GetSingleAsync(Expression<Func<Address, bool>> method)
        {
            Address address = await _addressRepository.GetSingleAsync(method);
            AddressDto addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }

        public ICollection<AddressDto> GetWhere(Expression<Func<Address, bool>> method)
        {
            List<Address> addresses = _addressRepository.GetWhere(method).ToList();
            List<AddressDto> addressDtos = _mapper.Map<List<AddressDto>>(addresses);
            return addressDtos;
        }

        public async Task Remove(long id)
        {
            await _addressRepository.Remove(id);
        }

        public void Remove(AddressDto model)
        {
            _addressRepository.Remove(_mapper.Map<Address>(model));
        }

        public void RemoveRange(List<AddressDto> datas)
        {
            _addressRepository.RemoveRange(_mapper.Map<List<Address>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(AddressDto model)
        {
            _addressRepository.Update(_mapper.Map<Address>(model));
        }
    }
}
