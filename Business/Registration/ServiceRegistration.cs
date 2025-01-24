//using AutoMapper;
//using CV.Business.MapProfile;
//using CV.Business.Services.Abstract;
//using CV.Business.Services.Concrete;
//using CV.DataAccess.Contexts;
//using CV.DataAccess.Repositories.Abstract;
//using CV.DataAccess.Repositories.Concrete;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CV.Business.Registration
//{
//    public static class ServiceRegistration {
//        public static IServiceCollection ServiceRegistrationBusiness(this IServiceCollection services, string connectionString)
//        {
//            services.AddDbContext<CvApplicationContext>(x =>
//            {
//                x.UseSqlServer(connectionString);
//            });
//            services.AddAutoMapper(typeof(MapProfile.MapProfile).Assembly);
//            services.AddScoped<IPersonRepository, PersonRepository>();
//            services.AddScoped<IAddressRepository, AddressRepository>();
//            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
//            services.AddScoped<ICertificateRepository, CertificateRepository>();
//            services.AddScoped<IReferenceRepository, ReferenceRepository>();
//            services.AddScoped<ISkillRepository, SkillRepository>();
//            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
//            services.AddScoped<IEducationRepository, EducationRepository>();
//            services.AddScoped<IProjectRepository, ProjectRepository>();
//            services.AddScoped<IPersonService, PersonService>();
//            services.AddScoped<IAddressService, AddressService>();
//            services.AddScoped<IAttachmentService, AttachmentService>();
//            services.AddScoped<ICertificateService, CertificateService>();
//            services.AddScoped<IReferenceService, ReferenceService>();
//            services.AddScoped<ISkillService, SkillService>();
//            services.AddScoped<ISocialMediaService, SocialMediaService>();
//            services.AddScoped<IEducationService, EducationService>();
//            services.AddScoped<IProjectService, ProjectService>();
//            return services;
//        }

//    }
    
//}
