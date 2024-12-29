using DAL.Models;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IPageService
    {
        Task<PageViewModel> AddPage(PageViewModel model);
        EntityList<PageViewModel> GetPages(int pageNumber, int pageSize);

        Task<PageViewModel> UpdatePage(PageViewModel model);

        Task<PageViewModel> DeletePage(int id);

        List<PageViewModel> GetAllPage();
        Task<PageViewModel?> GetPage(int id);

        bool SystemNameAlreadyExist(PageViewModel model);

    }

}
