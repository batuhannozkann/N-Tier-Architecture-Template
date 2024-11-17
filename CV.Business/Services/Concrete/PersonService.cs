using AutoMapper;
using CV.Business.Services.Abstract;
using CV.Core.DTOs.Person;
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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonDto> AddAsync(CreatePersonDto model)
        {
            Person person = _mapper.Map<Person>(model);
            var result = await _personRepository.AddAsync(person);
            return _mapper.Map<PersonDto>(result);
        }

        public async Task<List<PersonDto>> AddRangeAsync(List<CreatePersonDto> model)
        {
            List<Person> persons = _mapper.Map<List<Person>>(model);
            var result = await _personRepository.AddRangeAsync(persons);
            return _mapper.Map<List<PersonDto>>(result);
        }

        public ICollection<PersonDto> GetAll()
        {
            List<PersonDto> persons = _mapper.Map<List<PersonDto>>(_personRepository.GetAll().ToList());
            return persons;
        }

        public async Task<PersonDto> GetByIdAsync(long id)
        {
            Person person = await _personRepository.GetByIdAsync(id);
            PersonDto personDto = _mapper.Map<PersonDto>(person);
            return personDto;
        }

        public async Task<PersonDto> GetSingleAsync(Expression<Func<Person, bool>> method)
        {
            Person person = await _personRepository.GetSingleAsync(method);
            PersonDto personDto = _mapper.Map<PersonDto>(person);
            return personDto;
        }

        public ICollection<PersonDto> GetWhere(Expression<Func<Person, bool>> method)
        {
            List<Person> persons = _personRepository.GetWhere(method).ToList();
            List<PersonDto> personDtos = _mapper.Map<List<PersonDto>>(persons);
            return personDtos;
        }

        public async Task Remove(long id)
        {
            await _personRepository.Remove(id);
        }

        public void Remove(PersonDto model)
        {
            
            _personRepository.Remove(_mapper.Map<Person>(model));
        }

        public void RemoveRange(List<PersonDto> datas)
        {
            _personRepository.RemoveRange(_mapper.Map<List<Person>>(datas));
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(PersonDto model)
        {
            _personRepository.Update(_mapper.Map<Person>(model));
        }
    }
}
