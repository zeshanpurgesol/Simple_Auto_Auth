using DAL.Models;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Profile, ProfileViewModel>().ReverseMap();
            CreateMap<Page, PageViewModel>().ReverseMap();
        }
    }
}
