using AutoMapper;
using programmersBlog.Entities.Concrete;
using programmersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            // creats Dateon AerticleAddDto if not and gives value (Beacuse no date field in ArticleAddDto)
            CreateMap<ArticleAddDto, Article>().ForMember(dest=>dest.createdDate,opt=>opt.MapFrom(x=>DateTime.Now));
            CreateMap<ArticleUpdatDto, Article>().ForMember(dest=>dest.modifiedDate,opt=>opt.MapFrom(x=>DateTime.Now));
        }
    }
}
