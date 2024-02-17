using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            // creats Dateon AerticleAddDto if not and gives value (Beacuse no date field in ArticleAddDto)
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.createdDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticleUpdatDto, Article>().ForMember(dest => dest.modifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
