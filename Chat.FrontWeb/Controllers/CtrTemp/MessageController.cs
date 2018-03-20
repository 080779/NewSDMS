
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.Member;
using SDMS.Web.Models.Message;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CtrTemp.SDMS.Web.Controllers
{
    public class MessageController : FrontBaseController
    {
        public ILeavewordsService LeavewordsService { get; set; }
        public IUserService user { get; set; }
        public INewsService NewsService { get; set; }
        //int pageSize = 2;
        //我要留言
        public ActionResult Leavewords()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Leavewords( string Title, string Context)
        {
            long UserID = GetLoginID();

            if (Title == "")
            {
                return Json(new AjaxResult { Msg = "标题不能为空" });
            }
            if (Context == "")
            {
                return Json(new AjaxResult { Msg = "内容不能为空" });
            }
            long result = LeavewordsService.Add(UserID, Title, Context);

            if (result > 0)
                return Json(new AjaxResult { Msg = "添加成功" });
            else
                return Json(new AjaxResult { Msg = "添加失败" });

        }
        //发件箱
        public ActionResult LeaveOut()
        {
            long userid = GetLoginID();
            int FromUserType = 1;
            int PageIndex = 1;

            LeaveOutListModel model = new LeaveOutListModel();

            //查询数据
            LeaveOutPageResult leaveoutModel = new LeaveOutPageResult();
            leaveoutModel = LeavewordsService.GetPageList(userid, FromUserType, PageIndex, pageSize);
           

            model.leaveoutList = leaveoutModel.LeaveOuts;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = PageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = leaveoutModel.TotalCount;

            if (leaveoutModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult LeaveOut(int pageIndex = 1)
        {
            long userid = GetLoginID();
            int FromUserType = 1;
         
            LeaveOutListModel model = new LeaveOutListModel();

            //查询数据
            LeaveOutPageResult leaveoutModel = new LeaveOutPageResult();
            leaveoutModel = LeavewordsService.GetPageList(userid, FromUserType, pageIndex, pageSize);

            model.leaveoutList = leaveoutModel.LeaveOuts;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = leaveoutModel.TotalCount;

            if (leaveoutModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }
        //收件箱
        public ActionResult leaveMsg()
        {
            long userid = GetLoginID();
            int ToUserType = 2;
            int PageIndex = 1;

            LeaveMsgListModel model = new LeaveMsgListModel();

            //查询数据
            LeaveMsgPageResult LeaveMsgModel = new LeaveMsgPageResult();
            LeaveMsgModel = LeavewordsService.GetLeaveMsgPageList(userid, ToUserType, PageIndex, pageSize);

            model.leaveMsgList = LeaveMsgModel.LeaveMsg;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = PageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = LeaveMsgModel.TotalCount;

            if (LeaveMsgModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult leaveMsg(int pageIndex = 1)
        {
            long userid = GetLoginID();
            int ToUserType = 2;

            LeaveMsgListModel model = new LeaveMsgListModel();


            //查询数据
            LeaveMsgPageResult LeaveMsgModel = new LeaveMsgPageResult();
            LeaveMsgModel = LeavewordsService.GetLeaveMsgPageList(userid, ToUserType, pageIndex, pageSize);

            model.leaveMsgList = LeaveMsgModel.LeaveMsg;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = LeaveMsgModel.TotalCount;

            if (LeaveMsgModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }

        //留言详情
        public ActionResult LeaveWordsDetail(long Id)
        {
            LeaveWordsDetailModel model = new LeaveWordsDetailModel();
            model.data = LeavewordsService.GetModelByID(Id);
            LeaveReMsgPageResult leaveModel = new LeaveReMsgPageResult();
            leaveModel = LeavewordsService.GetLeaveReMsgPageList(Id, 1, pageSize);
            model.leaveReMsgList = leaveModel.Leaveremsgs;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = pageSize;
            pager.TotalCount = leaveModel.TotalCount;

            if (leaveModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult LeaveWordsDetail(long Id, int pageIndex = 1)
        {
            LeaveWordsDetailModel model = new LeaveWordsDetailModel();


            //查询数据
            LeaveReMsgPageResult leaveModel = new LeaveReMsgPageResult();
            leaveModel = LeavewordsService.GetLeaveReMsgPageList(Id, pageIndex, pageSize);

            model.leaveReMsgList = leaveModel.Leaveremsgs;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = leaveModel.TotalCount;

            if (leaveModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }
        //回复留言
        public ActionResult LeaveWordsContext()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LeaveWordsContext(long Id, string Context)
        {
            long userid = GetLoginID();
            string UserCode = user.GetModel(userid).UserCode;
             if (Context == "")
            {
                return Json(new AjaxResult { Msg = "内容不能为空" });
            }
            long result = LeavewordsService.LeaveReMsgAdd(Id, userid, UserCode, Context);

            if (result > 0)
                return Json(new AjaxResult { Msg = "添加成功" });
            else
                return Json(new AjaxResult { Msg = "添加失败" });

        }
        //新闻列表
       
        public ActionResult NoticeManage(string Title, DateTime? Strat, DateTime? End)
        {
            int NewType = 0;
            int PageIndex = 1;
            NoticeMabageListModel model = new NoticeMabageListModel();
            
            //查询数据
            NewsPageResult newsModel = new NewsPageResult();
            newsModel = NewsService.GetNewsList(NewType,Title, Strat, End, PageIndex, pageSize);

            model.newsList = newsModel.News;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = PageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = newsModel.TotalCount;

            if (newsModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return View(model);
        }

        [HttpPost]
        //新闻列表

        public ActionResult NoticeManage(string Title, DateTime? Strat, DateTime? End, int PageIndex = 1)
        {
            int NewType = 0;
            
            NoticeMabageListModel model = new NoticeMabageListModel();

            //查询数据
            NewsPageResult newsModel = new NewsPageResult();
            newsModel = NewsService.GetNewsList(NewType,Title, Strat, End, PageIndex, pageSize);

            model.newsList = newsModel.News;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = PageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = newsModel.TotalCount;

            if (newsModel.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return View(model);
        }
    }
}