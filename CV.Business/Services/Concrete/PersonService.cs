using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Person;
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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<PersonDto>> AddAsync(CreatePersonDto model)
        {
            var person = _mapper.Map<Person>(model);

            // Repository'e gönder
            var result = await _personRepository.AddPersonWithRelatedEntitiesAsync(person);

            return new ResponseDto<PersonDto>
            {
                Data = _mapper.Map<PersonDto>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Person and related entities successfully created",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<List<PersonDto>>> AddRangeAsync(List<CreatePersonDto> model)
        {
            List<Person> persons = _mapper.Map<List<Person>>(model);
            var result = await _personRepository.AddRangeAsync(persons);
            return new ResponseDto<List<PersonDto>>
            {
                Data = _mapper.Map<List<PersonDto>>(result),
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Persons successfully created",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<PersonDto>> GetAll()
        {
            var persons = _mapper.Map<List<PersonDto>>(_personRepository.GetAll().ToList());
            return new ResponseDto<ICollection<PersonDto>>
            {
                Data = persons,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Persons successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<PersonDto>> GetByIdAsync(long id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return new ResponseDto<PersonDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Person not found",
                    IsSuccess = false
                };

            return new ResponseDto<PersonDto>
            {
                Data = _mapper.Map<PersonDto>(person),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Person successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDto<PersonDto>> GetSingleAsync(Expression<Func<Person, bool>> method)
        {
            var person = await _personRepository.GetSingleAsync(method);
            if (person == null)
                return new ResponseDto<PersonDto>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "Person not found",
                    IsSuccess = false
                };

            return new ResponseDto<PersonDto>
            {
                Data = _mapper.Map<PersonDto>(person),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Person successfully retrieved",
                IsSuccess = true
            };
        }

        public ResponseDto<ICollection<PersonDto>> GetWhere(Expression<Func<Person, bool>> method)
        {
            var persons = _personRepository.GetWhere(method).ToList();
            return new ResponseDto<ICollection<PersonDto>>
            {
                Data = _mapper.Map<List<PersonDto>>(persons),
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Persons successfully retrieved",
                IsSuccess = true
            };
        }

        public async Task<ResponseDtoWithoutData> Remove(long id)
        {
            await _personRepository.Remove(id);
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Person successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData Remove(PersonDto model)
        {
            _personRepository.Remove(_mapper.Map<Person>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Person successfully deleted",
                IsSuccess = true
            };
        }

        public ResponseDtoWithoutData RemoveRange(List<PersonDto> datas)
        {
            _personRepository.RemoveRange(_mapper.Map<List<Person>>(datas));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Persons successfully deleted",
                IsSuccess = true
            };
        }

        public async Task<int> SaveAsync()
        {
            return await _personRepository.SaveAsync();
        }

        public async Task<ResponseDtoWithoutData> Update(PersonDto model)
        {
            _personRepository.Update(_mapper.Map<Person>(model));
            return new ResponseDtoWithoutData
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Person successfully updated",
                IsSuccess = true
            };
        }
    }
}
