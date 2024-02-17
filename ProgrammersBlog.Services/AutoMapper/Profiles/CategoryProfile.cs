using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // creats Dateon AerticleAddDto if not and gives value (Beacuse no date field in ArticleAddDto)
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.createdDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.modifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Category, CategoryUpdatDto>();

        }
    }
}
