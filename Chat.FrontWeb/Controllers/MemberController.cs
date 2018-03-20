using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.Member;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class MemberController : FrontBaseController
    {
        public ILeavewordsService LeavewordsService { get; set; }
        public IMemberService MemberService { get; set; }
        public ILevelService Level { get; set; }
        public IUserService user { get; set; }
        int pageSize = 2;
        public ActionResult Member(int pageIndex = 1)
        {
           
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
                new SelectListItem(){Value="2",Text="推荐人编号"},
            };
            MemberListViewModel model = new MemberListViewModel();
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = MemberService.GetMemberList("0",1, "", "0", null, null, pageIndex, pageSize, 0).TotalCount;

            if (pager.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            model.BlogCategory = Level.GetAll();
            model.MemberList = MemberService.GetMemberList("0", 1, "", "0", null, null, pageIndex, pageSize, 0).MemberList;
            return View(model);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="usercode"></param>
        /// <param name="Level"></param>
        /// <param name="Strat"></param>
        /// <param name="End"></param>
        /// <param name="i">I为0就是查询未开通</param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult MemberGetPage(string Id,int getloginid, string usercode, string Level, DateTime? Strat, DateTime? End, int i, int pageIndex = 1)
        {
           
            MemberListViewModel model = new MemberListViewModel();
            MemberSearchResult result = MemberService.GetMemberList(Id, getloginid, usercode, Level, Strat, End, pageIndex, pageSize, i);
            model.MemberList = result.MemberList;

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
            return Json(new AjaxResult { Status = "1", Data = model });
        }
        //已开通会员
        public ActionResult MemberList(int pageIndex = 1)
        {
         
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
                new SelectListItem(){Value="2",Text="推荐人编号"},
            };
            MemberListViewModel model = new MemberListViewModel();
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = MemberService.GetMemberList("0", 1, "", "0", null, null, pageIndex, pageSize, 2).TotalCount;

            if (pager.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            model.BlogCategory = Level.GetAll();
            model.MemberList = MemberService.GetMemberList("0", 1, "", "0", null, null, pageIndex, pageSize, 2).MemberList;
            return View(model);
        } 
        public ActionResult Pass(long id)
        {
            //先查一遍有没有开通，然后在看登陆的人是不是和开通会员有关系
            int result = MemberService.Pass(id);
            if (result == 0)//不存在
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "激活失败，该会员不存在" });
            }
            else if (result == 1)//有值但是 会员已经开通
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "激活失败，该会员已激活" });
            }
            else if (result == 2)//成功
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "激活成功", Data = "/Member/Member" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "激活成功", Data = "/Member/Member" });

        }
        public ActionResult Del(long id)
        {
            int result = MemberService.Del(id);
            if (result == 0)//不存在
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "删除失败，该会员不存在" });
            }
            else if (result == 1)//有值但是 会员已经开通
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "删除失败，该会员已激活" });
            }
            else if (result == 2)//成功
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "删除成功", Data = "/Member/Member" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "删除成功", Data = "/Member/Member" });
        }
        //已注册会员
        public ActionResult RegisterList(int pageIndex = 1)
        { 
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
                new SelectListItem(){Value="2",Text="推荐人编号"},
            };
            MemberListViewModel model = new MemberListViewModel();
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = MemberService.GetMemberList("0", 1, "", "0", null, null, pageIndex, pageSize, 3).TotalCount;

            if (pager.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            model.BlogCategory = Level.GetAll();
            model.MemberList = MemberService.GetMemberList("0", 1, "", "0", null, null, pageIndex, pageSize, 3).MemberList;
            return View(model);
        }
       
    }
}