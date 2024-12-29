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
    public class UserService : IUserService
    {
        private IRepo<User> user_repo;
        private IMapper mapper;

        public UserService(IRepo<User> user_repo, IMapper mapper)
        {
            this.user_repo = user_repo;
            this.mapper = mapper;
        }

        public async Task<UserViewModel> AddUser(UserViewModel model)
        {
            var MappedObj = mapper.Map<User>(model);
            var res = await user_repo.Insert(MappedObj);
            return mapper.Map<UserViewModel>(res);
        }

        public async Task<UserViewModel> DeleteUser(int id)
        {
            var User = await user_repo.Delete(id);
            return mapper.Map<UserViewModel>(User);
            var Obj = await user_repo.Get(id);
            if (Obj == null)
            {
                return null!;
            }
            Obj.Status = (short)UpdateStatus.Deleted;
            var res = await user_repo.Update(Obj);
            return mapper.Map<UserViewModel>(res);
        }

        public List<UserViewModel> GetAllUser()
        {
            var res = user_repo.GetAll();
            return mapper.Map<List<UserViewModel>>(res);
        }

        public async Task<UserViewModel?> GetUser(int id)
        {
            var res = await user_repo.Get(id);
            return mapper.Map<UserViewModel>(res);
        }

        public EntityList<UserViewModel> GetUsers(int pageNumber, int pageSize)
        {
            var res=user_repo.GetAll(pageNumber, pageSize);
            return mapper.Map<EntityList<UserViewModel>>(res);
        }

        public bool SystemNameAlreadyExist(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> UpdateUser(UserViewModel model)
        {
            var MappedObj = mapper.Map<User>(model);
            var res = await user_repo.Update(MappedObj);
            return mapper.Map<UserViewModel>(res);
        }
    }

}
