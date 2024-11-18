using AutoMapper;
using CV.Core.DTOs.Address;
using CV.Core.DTOs.Attachment;
using CV.Core.DTOs.Certificate;
using CV.Core.DTOs.Education;
using CV.Core.DTOs.Person;
using CV.Core.DTOs.Project;
using CV.Core.DTOs.Reference;
using CV.Core.DTOs.Skill;
using CV.Core.DTOs.SocialMedia;
using CV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.MapProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person,CreatePersonDto>().ReverseMap();
            CreateMap<Attachment,AttachmentDto>().ReverseMap();
            CreateMap<Attachment,CreateAttachmentDto>().ReverseMap();
            CreateMap<Certificate,CertificateDto>().ReverseMap();
            CreateMap<Certificate,CreateCertificateDto>().ReverseMap();
            CreateMap<Education,EducationDto>().ReverseMap();
            CreateMap<Education, CreateEducationDto>().ReverseMap();
            CreateMap<Project,ProjectDto>().ReverseMap();
            CreateMap<Project,CreateProjectDto>().ReverseMap();
            CreateMap<Reference,ReferenceDto>().ReverseMap();
            CreateMap<Reference,CreateReferenceDto>().ReverseMap();
            CreateMap<Skill,SkillDto>().ReverseMap();
            CreateMap<Skill,CreateSkillDto>().ReverseMap();
            CreateMap<SocialMedia,SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();
            CreateMap<CreatePersonDto, Person>()
           .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.Certificates))
           .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.Projects))
           .ForMember(dest => dest.Educations, opt => opt.MapFrom(src => src.Educations))
           .ForMember(dest => dest.SocialMedias, opt => opt.MapFrom(src => src.SocialMedias))
           .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
           .ForMember(dest => dest.References, opt => opt.MapFrom(src => src.References))
           .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments))
           .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));
        }
    }
}
