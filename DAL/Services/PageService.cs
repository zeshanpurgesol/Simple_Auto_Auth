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
    public class PageService : IPageService
    {
        private IRepo<Page> Page_repo;
        private IMapper mapper;

        public PageService(IRepo<Page> Page_repo, IMapper mapper)
        {
            this.Page_repo = Page_repo;
            this.mapper = mapper;
        }

        public async Task<PageViewModel> AddPage(PageViewModel model)
        {
            model.Status =(short) UpdateStatus.Active;
            model.DateTime= DateTime.Now;
            model.UserId = 1;//----------------
            var MappedObj = mapper.Map<Page>(model);
            var res = await Page_repo.Insert(MappedObj);
            return mapper.Map<PageViewModel>(res);
        }

        public async Task<PageViewModel> DeletePage(int id)
        {
            var Page = await Page_repo.Delete(id);
            return mapper.Map<PageViewModel>(Page);
            var Obj = await Page_repo.Get(id);
            if (Obj == null)
            {
                return null!;
            }
            Obj.Status = (short)UpdateStatus.Deleted;
            var res = await Page_repo.Update(Obj);
            return mapper.Map<PageViewModel>(res);
        }

        public List<PageViewModel> GetAllPage()
        {
            var res = Page_repo.GetAll();
            return mapper.Map<List<PageViewModel>>(res);
        }

        public async Task<PageViewModel?> GetPage(int id)
        {
            var res = await Page_repo.Get(id);
            return mapper.Map<PageViewModel>(res);
        }

        public EntityList<PageViewModel> GetPages(int pageNumber, int pageSize)
        {
            var res=Page_repo.GetAll(pageNumber, pageSize);
            return mapper.Map<EntityList<PageViewModel>>(res);
        }

        public bool SystemNameAlreadyExist(PageViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<PageViewModel> UpdatePage(PageViewModel model)
        {
            var MappedObj = mapper.Map<Page>(model);
            var res = await Page_repo.Update(MappedObj);
            return mapper.Map<PageViewModel>(res);
        }
    }

}
