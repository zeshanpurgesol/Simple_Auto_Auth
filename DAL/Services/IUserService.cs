using DAL.Models;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IUserService
    {
        Task<UserViewModel> AddUser(UserViewModel model);
        EntityList<UserViewModel> GetUsers(int pageNumber, int pageSize);

        Task<UserViewModel> UpdateUser(UserViewModel model);

        Task<UserViewModel> DeleteUser(int id);

        List<UserViewModel> GetAllUser();
        Task<UserViewModel?> GetUser(int id);

        bool SystemNameAlreadyExist(UserViewModel model);

    }

}
