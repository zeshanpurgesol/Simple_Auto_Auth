using AutoMapper;
using DAL.Enums;
using DAL.Models;
using DAL.Repo;
using DAL.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ProfileService : IProfileService
    {
        private IRepo<Models.Profile> Profile_repo;
        private IMapper mapper;

        public ProfileService(IRepo<Models.Profile> Profile_repo, IMapper mapper)
        {
            this.Profile_repo = Profile_repo;
            this.mapper = mapper;
        }

        public async Task<ProfileViewModel> AddProfile(ProfileViewModel model)
        {
            model.Status =(short) UpdateStatus.Active;
            model.DateTime= DateTime.Now;
            model.UserId = 1;//----------------
            var MappedObj = mapper.Map<Models.Profile>(model);
            var res = await Profile_repo.Insert(MappedObj);
            return mapper.Map<ProfileViewModel>(res);
        }

        public async Task<ProfileViewModel> DeleteProfile(int id)
        {
            var Profile = await Profile_repo.Delete(id);
            return mapper.Map<ProfileViewModel>(Profile);
            var Obj = await Profile_repo.Get(id);
            if (Obj == null)
            {
                return null!;
            }
            Obj.Status = (short)UpdateStatus.Deleted;
            var res = await Profile_repo.Update(Obj);
            return mapper.Map<ProfileViewModel>(res);
        }

        public List<ProfileViewModel> GetAllProfile()
        {
            var res = Profile_repo.GetAll();
            return mapper.Map<List<ProfileViewModel>>(res);
        }

        public List<ProfileViewModel> GetAllProfile(int id)
        {
            var res = Profile_repo.GetAll().Where(x=>x.UserId==id);
            return mapper.Map<List<ProfileViewModel>>(res);
        }

        public async Task<ProfileViewModel?> GetProfile(int id)
        {
            var res = await Profile_repo.Get(id);
            return mapper.Map<ProfileViewModel>(res);
        }

        public EntityList<ProfileViewModel> GetProfiles(int ProfileNumber, int ProfileSize)
        {
            var res=Profile_repo.GetAll(ProfileNumber, ProfileSize);
            return mapper.Map<EntityList<ProfileViewModel>>(res);
        }

        public bool SystemNameAlreadyExist(ProfileViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileViewModel> UpdateProfile(ProfileViewModel model)
        {
            var MappedObj = mapper.Map<Models.Profile>(model);
            var res = await Profile_repo.Update(MappedObj);
            return mapper.Map<ProfileViewModel>(res);
        }

   }

}
