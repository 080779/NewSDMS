using SDMS.Common;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class HomeController : FrontBaseController
    {
        public INewsService newsService { get; set; }
        //public IHolderService holderService { get; set; }
        public IJournalService journalService { get; set; }
        public IMessageService messageService { get; set; }
        public ActionResult Index(int pageIndex=1)
        {
            int pageSize = 5;
            NewsListViewModel model = new NewsListViewModel();
            NewsSearchResult result = newsService.GetPageList(null, null, null, pageIndex, pageSize);
            model.News = result.News;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = result.TotalCount;

            if (result.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }

            return View(model);
        }
        public ActionResult Details(long id)
        {
            var dto = newsService.GetById(id);
            if(dto==null)
            {
                dto = new NewsDTO();
            }
            return View(dto);
        }
        [HttpGet]
        public ActionResult Message(long id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Message(long id,string contents)
        {
            if(string.IsNullOrEmpty(contents))
            {
                return Json(new AjaxResult { Status="0",Msg="消息不能为空"});
            }
            long bid= messageService.AddNew(2,id, contents);
            return Json(new AjaxResult { Status = "1",Data= bid });
        }
        public ActionResult Share()
        {
            ShareBonusViewModel model = new ShareBonusViewModel();
            model.Holder = holderService.GetById(2);
            model.YesterdayBonus = journalService.YesterdayBonus(2);
            model.Journals = journalService.GetBonusList(2, 5);
            return View(model);
        }

        [HttpGet]
        public ActionResult SetPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetPwd(long id, string oldTradePwd, string tradePwd)
        {
            return Json(new AjaxResult { Status = "1", Data = "/home/index" });
        }
    }
}