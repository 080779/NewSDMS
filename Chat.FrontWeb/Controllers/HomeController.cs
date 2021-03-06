﻿using SDMS.Common;
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
    //public class HomeController : Controller
    {
        public INewsService newsService { get; set; }
        //public IHolderService holderService { get; set; }
        public IJournalService journalService { get; set; }
        public IMessageService messageService { get; set; }
        public IReadNumberService readNumberService { get; set; }
        public ISettingsService settingsService { get; set; }
        //public long UserId = 1;
        [HttpGet]
        public ActionResult Index()
        {
            var model =settingsService.GetByName("imgurl");
            string aa;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int pageIndex = 1)
        {
            NewsSearchResult result = newsService.GetPageList(null, null, null, pageIndex, pageSize);
            return Json(new AjaxResult { Status = "1", Data = result.News });
        }
        public ActionResult Details(long id)
        {
            readNumberService.AddNew(UserId, id);
            string cacheKey = "NewsDetails_" + id;
            var dto = (NewsDTO)HttpContext.Cache[cacheKey];//asp.net 内置缓存，先看缓存中有没有
            if(dto==null)
            {
                dto = newsService.GetById(id);
                HttpContext.Cache.Insert(cacheKey, dto, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);//没有就在数据库里读，然后写入缓存
                if (dto == null)
                {
                    dto = new NewsDTO();
                }
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
            long bid= messageService.AddNew(UserId,id, contents);
            return Json(new AjaxResult { Status = "1" });
        }
        public ActionResult Share()
        {
            ShareBonusViewModel model = new ShareBonusViewModel();
            model.Holder = holderService.GetById(UserId);
            if (model.Holder == null)
            {
                Session["UserId"] = null;
                Session["OpenId"] = null;
                Session["HeadImgUrl"] = null;
                return Redirect("/home/index");
            }
            model.YesterdayBonus = journalService.YesterdayBonus(UserId);
            model.Journals = journalService.GetPageList(UserId,null,null,"分红",null,null ,null,1,10).Journals;
            holderService.SetPoint(UserId);
            return View(model);
        }
        public ActionResult GetPoint()
        {            
            return Json(new AjaxResult { Status = "1", Data = holderService.GetPoint(UserId) });
        }
        [HttpGet]
        public ActionResult SetPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetPwd(string oldTradePwd, string tradePwd)
        {
            long result = holderService.SetTradePwd(UserId, oldTradePwd, tradePwd);
            if (result<=0)
            {
                if(result==-2)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "旧交易密码错误" });
                }
                return Json(new AjaxResult { Status = "0",Msg="修改失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/myinfo/list" });
        }
    }
}