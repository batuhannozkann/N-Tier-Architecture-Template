using CV.Core.Entities;
using CV.Core.Repositories.Concrete;
using CV.DataAccess.Contexts;
using CV.DataAccess.Repositories.Abstract;

namespace CV.DataAccess.Repositories.Concrete
{
    public class PersonRepository : BaseRepository<Person, CvApplicationContext>,IPersonRepository
    {
        public PersonRepository(CvApplicationContext context) : base(context)
        {
        }
        public async Task<Person> AddPersonWithRelatedEntitiesAsync(Person person)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Ana person entity'sini ekle
                await _context.Persons.AddAsync(person);

                // İlişkili entityleri ekle
                if (person.Certificates != null)
                    await _context.Certificates.AddRangeAsync(person.Certificates);

                if (person.Projects != null)
                    await _context.Projects.AddRangeAsync(person.Projects);

                if (person.Educations != null)
                    await _context.Educations.AddRangeAsync(person.Educations);

                if (person.SocialMedias != null)
                    await _context.SocialMedias.AddRangeAsync(person.SocialMedias);

                if (person.Skills != null)
                    await _context.Skills.AddRangeAsync(person.Skills);

                if (person.References != null)
                    await _context.References.AddRangeAsync(person.References);

                if (person.Attachments != null)
                    await _context.Attachments.AddRangeAsync(person.Attachments);

                if (person.Addresses != null)
                    await _context.Addresses.AddRangeAsync(person.Addresses);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return person;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}



