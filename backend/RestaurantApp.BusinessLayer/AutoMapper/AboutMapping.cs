using AutoMapper;
using RestaurantApp.DtoLayer.AboutDto;
using RestaurantApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BusinessLayer.AutoMapper
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap(); 
            CreateMap<About, UpdateAboutDto>().ReverseMap(); 
            CreateMap<About, CreateAboutDto>().ReverseMap(); 
            CreateMap<About, GetAboutDto>().ReverseMap(); 
        }
    }
}
