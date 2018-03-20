using SDMS.DTO.DTO;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models;
using SDMS.Web.Areas.Admin.Models.Message;
using SDMS.IService.Interface;
using SDMS.Service.Service;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class MessageController : AdminBaseController
    {
        public ILeavewordsService LeavewordsService { get; set; }
        public IUserService UserService { get; set; }
        public IAdminService AdminService { get; set; }
        public INewsService NewsService { get; set; }
        int PageSize = 10;
        public ActionResult Leavewords()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Leavewords(long UserID,string UserCode, string Title, string Context)
        {
            if (UserCode == "")
            {
                return Json(new AjaxResult { Msg = "留言对象不能为空" });
            }
            var user = UserService.GetModelCode(UserCode);
            if (user == null)
            {
                return Json(new AjaxResult { Msg = "留言对象不存在" });
            }
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


        public ActionResult LeaveOut()
        {
            long userid = GetLoginID();
            int FromUserType = 1;
            int PageIndex = 1;
            LeaveOutListModel model = new LeaveOutListModel();
            
            //查询数据
            LeaveOutPageResult leaveoutModel = new LeaveOutPageResult();
            
            leaveoutModel = LeavewordsService.GetPageList(userid, FromUserType, PageIndex, PageSize);
            model.leaveoutList = leaveoutModel.LeaveOuts;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = leaveoutModel.TotalCount;

            if (leaveoutModel.TotalCount <= PageSize)
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
        public ActionResult LeaveOut(int pageIndex=1)
        {
            long userid = GetLoginID();
            int FromUserType = 1;
            LeaveOutListModel model = new LeaveOutListModel();
            
            //查询数据
            LeaveOutPageResult leaveoutModel = new LeaveOutPageResult();
            leaveoutModel = LeavewordsService.GetPageList(userid, FromUserType, pageIndex, PageSize);

            model.leaveoutList = leaveoutModel.LeaveOuts;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = leaveoutModel.TotalCount;

            if (leaveoutModel.TotalCount <= PageSize)
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
        public ActionResult LeaveIn()
        {
            long userid = GetLoginID();
            int ToUserType = 2;
            int PageIndex = 1;
            LeaveOutListModel model = new LeaveOutListModel();
            
            //查询数据
            LeaveOutPageResult leaveoutModel = new LeaveOutPageResult();
            
            leaveoutModel = LeavewordsService.GetPageList(userid, ToUserType, PageIndex, PageSize);
            model.leaveoutList = leaveoutModel.LeaveOuts;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = PageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = leaveoutModel.TotalCount;

            if (leaveoutModel.TotalCount <= PageSize)
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
        public ActionResult LeaveIn(int pageIndex = 1)
        {
            long userid = GetLoginID();
            int ToUserType = 2;
            LeaveOutListModel model = new LeaveOutListModel();
            //查询数据
            LeaveOutPageResult leaveoutModel = new LeaveOutPageResult();
            leaveoutModel = LeavewordsService.GetPageList(userid, ToUserType, pageIndex, PageSize);
            model.leaveoutList = leaveoutModel.LeaveOuts;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = leaveoutModel.TotalCount;

            if (leaveoutModel.TotalCount <= PageSize)
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
            leaveModel = LeavewordsService.GetLeaveReMsgPageList(Id, 1, PageSize);
            model.leaveReMsgList = leaveModel.Leaveremsgs;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = leaveModel.TotalCount;

            if (leaveModel.TotalCount <= PageSize)
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
            leaveModel = LeavewordsService.GetLeaveReMsgPageList(Id, pageIndex, PageSize);

            model.leaveReMsgList = leaveModel.Leaveremsgs;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = leaveModel.TotalCount;

            if (leaveModel.TotalCount <= PageSize)
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
            
            if (Context == "")
            {
                return Json(new AjaxResult { Msg = "内容不能为空" });
            }
            long result = LeavewordsService.ContentAdd(Id, Context);

            if (result > 0)
                return Json(new AjaxResult { Msg = "添加成功" });
            else
                return Json(new AjaxResult { Msg = "添加失败" });

        }

        //新闻公告
        public ActionResult NoticeEdit(long id=0)
        {
            NewsDTO dto = NewsService.GetModel(id);
            if (dto == null)
            {
                dto = new NewsDTO();
                dto.PublishTime = DateTime.Now;
                dto.NewType = 0;
            }
            return View(dto);
            
        }
        [HttpPost]
        public ActionResult NoticeEdit(string Title, int dropNewType, string Context, DateTime Time)
        {

            if (Title == "")
            {
                return Json(new AjaxResult { Msg = "标题不能为空" });
            }
            if (Context == "")
            {
                return Json(new AjaxResult { Msg = "内容不能为空" });
            }

            long result = NewsService.Add(Title, dropNewType, Context, Time);

            if (result > 0)
                return Json(new AjaxResult { Msg = "添加成功" });
            else
                return Json(new AjaxResult { Msg = "添加失败" });

        }
        [HttpPost]
        public ActionResult NoticeEditUpdate(NewsDTO hh)
        {
           bool result = NewsService.Update(hh);

            if (result)
                return Json(new AjaxResult { Msg = "修改成功" });
            else
                return Json(new AjaxResult { Msg = "修改失败" });

        }
        //公告列表
        public ActionResult NoticeManage()
        {
            NoticeMabageListModel model = new NoticeMabageListModel();

            //查询数据
            NewsPageResult newsModel = new NewsPageResult();
            newsModel = NewsService.GetPageList( 1, PageSize);

            model.newsList = newsModel.News;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = newsModel.TotalCount;

            if (newsModel.TotalCount <= PageSize)
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
        public ActionResult NoticeManage(string usercode, int pageIndex = 1)
        {
            NoticeMabageListModel model = new NoticeMabageListModel();


            //查询数据
            NewsPageResult newsModel = new NewsPageResult();
            newsModel = NewsService.GetPageList(pageIndex, PageSize);

            model.newsList = newsModel.News;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = newsModel.TotalCount;

            if (newsModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }

    }
}