﻿using CV.Core.Entities;
using CV.Core.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Abstract
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> AddPersonWithRelatedEntitiesAsync(Person person);
    }

}
