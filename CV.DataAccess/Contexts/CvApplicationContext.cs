using CV.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CV.DataAccess.Contexts
{
    public class CvApplicationContext :DbContext
    {
        public CvApplicationContext(DbContextOptions<CvApplicationContext> options):base(options)
        {

        }
        public DbSet<Project> Addresses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
