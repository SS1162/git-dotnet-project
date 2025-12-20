using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using DTO;

namespace Services
{
    public class AutoMapper:Profile
    {

        public AutoMapper() {


            CreateMap<User, UserDTO>();

           

            CreateMap<RegisterUserDTO, User>().ForMember(
                dest=>dest.Password,
                opts=>opts.MapFrom(src=>src.UserPassward));

            CreateMap<LoginUserDTO, User>().ForMember(
                dest => dest.Password,
                opts => opts.MapFrom(src => src.UserPassward));

            

            CreateMap<MainCategory, MainCategoriesDTO>().ReverseMap();

          
            CreateMap<ManegerMainCategoryDTO, MainCategory>();

            CreateMap<UpdateUserDTO, User>();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<AddCategoryDTO, Category>();

            CreateMap<Platform, PlatformsDTO>().ReverseMap();

            CreateMap<AddPlatformDTO, Platform>();
        }
   
    }
}
