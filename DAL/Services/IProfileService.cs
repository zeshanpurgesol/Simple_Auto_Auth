using DAL.Models;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IProfileService
    {
        Task<ProfileViewModel> AddProfile(ProfileViewModel model);
        EntityList<ProfileViewModel> GetProfiles(int pageNumber, int pageSize);

        Task<ProfileViewModel> UpdateProfile(ProfileViewModel model);

        Task<ProfileViewModel> DeleteProfile(int id);

        List<ProfileViewModel> GetAllProfile(int id);
        List<ProfileViewModel> GetAllProfile();
        Task<ProfileViewModel?> GetProfile(int id);

        bool SystemNameAlreadyExist(ProfileViewModel model);

    }

}
