using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Address;
using CV.Core.Entities;
using CV.DataAccess.Repositories.Abstract;
using CV.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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

        public async Task<ResponseDto<AddressDto>> AddAsync(CreateAddressDto model)
        {
            Address address = _mapper.Map<Address>(model);
            address.Person = await _personRepository.GetByIdAsync(model.PersonId);
            var result = await _addressRepository.AddAsync(address);
            return new ResponseDto<AddressDto>
            {
                Data = _mapper.Map<AddressDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Address successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<AddressDto>>> AddRangeAsync(List<CreateAddressDto> model)
        {
            List<Address> addresses = _mapper.Map<List<Address>>(model);
            for (int i = 0; i < model.Count; i++)
            {
                addresses[i].Person = await _personRepository.GetByIdAsync(model[i].PersonId);
            }
            var result = await _addressRepository.AddRangeAsync(addresses);
            return new ResponseDto<List<AddressDto>>
            {
                Data = _mapper.Map<List<AddressDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Addresses successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<AddressDto>> GetAll()
        {
            var addresses = _mapper.Map<List<AddressDto>>(_addressRepository.GetAll().ToList());
            return new ResponseDto<ICollection<AddressDto>>
            {
                Data = addresses,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Addresses successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<AddressDto>> GetByIdAsync(long id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null)
                return new ResponseDto<AddressDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Address not found",
                    IsSuccess = false
                };

            return new ResponseDto<AddressDto>
            {
                Data = _mapper.Map<AddressDto>(address),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Address successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<AddressDto>> GetSingleAsync(Expression<Func<Address, bool>> method)
        {
            var address = await _addressRepository.GetSingleAsync(method);
            if (address == null)
                return new ResponseDto<AddressDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Address not found",
                    IsSuccess = false
                };

            return new ResponseDto<AddressDto>
            {
                Data = _mapper.Map<AddressDto>(address),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Address successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<AddressDto>> GetWhere(Expression<Func<Address, bool>> method)
        {
            var addresses = _addressRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<AddressDto>>
            {
                Data = _mapper.Map<List<AddressDto>>(addresses),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Addresses successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _addressRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Address successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(AddressDto model)
        {
            _addressRepository.Remove(_mapper.Map<Address>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Address successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<AddressDto> datas)
        {
            _addressRepository.RemoveRange(_mapper.Map<List<Address>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Addresses successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _addressRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(AddressDto model)
        {
            _addressRepository.Update(_mapper.Map<Address>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Address successfully updated",
                IsSuccess = true
            };
        }
    }

}
