using SDMS.DTO.DTO;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models.Member;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class MemberController : AdminBaseController
    {
        // GET: Admin/Member
        public IMemberService MemberService { get; set; }
        public ILevelService Level { get; set; }
        public int pageSize = 2;
        //未开通会员
        public ActionResult Member(int pageIndex = 1)
        {

            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
                new SelectListItem(){Value="2",Text="推荐人编号"},
            };
            MemberListViewModel model = new MemberListViewModel();  
            model.BlogCategory = Level.GetAll(); 
            return View(model);
        }
        public PartialViewResult Member_Page(string Id, string usercode, string Level_1, DateTime? Strat, DateTime? End, int i, int pageIndex = 1)
        {

            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
                new SelectListItem(){Value="2",Text="推荐人编号"},
            };
            if (Level_1==null)
            {
                Level_1 = "0";
            }
            MemberListViewModel model = new MemberListViewModel();
            MemberSearchResult result = MemberService.GetMemberList(Id, usercode, Level_1, Strat, End, pageIndex, pageSize, i);
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
            model.MemberList = result.MemberList;
            model.BlogCategory = Level.GetAll();
            string Table = "";
            if (i == 0)
            {
                Table = "MemberPage";
            }
            else
            {
                Table = "MemberListPage";
            }

            return PartialView(Table, model);
        }




        public ActionResult Chaxun(string Id, string usercode, string Level, DateTime? Strat, DateTime? End, int IsoPen)
        {
            MemberService.GetMemberList(Id, usercode, Level, Strat, End, 1, 2, IsoPen);
            if (IsoPen == 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/admin/Member/Member" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/Member/MemberList" });
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
        public ActionResult MemberGetPage(string Id, string usercode, string Level, DateTime? Strat, DateTime? End, int i, int pageIndex = 1)
        {
            MemberListViewModel model = new MemberListViewModel();
            MemberSearchResult result = MemberService.GetMemberList(Id, usercode, Level, Strat, End, pageIndex, pageSize, i);
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
        public ActionResult Pass(long id)
        {
            int result = MemberService.Del(id);
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
                return Json(new AjaxResult { Status = result.ToString(), Msg = "激活成功", Data = "/admin/Member/Member" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "激活成功", Data = "/admin/Member/Member" });

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
                return Json(new AjaxResult { Status = result.ToString(), Msg = "删除成功", Data = "/admin/Member/Member" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "删除成功", Data = "/admin/Member/Member" });
        }
        //------------------------------------------------------------------------------
        //已开通会员
        public ActionResult MemberList(int pageIndex = 1)
        { 
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
                new SelectListItem(){Value="2",Text="推荐人编号"},
            };
            MemberListViewModel model = new MemberListViewModel(); 
            model.BlogCategory = Level.GetAll(); 
            return View(model);
        }
        public ActionResult Open(long id)
        {
            int result = MemberService.Open(id);
            if (result == 0)//不存在
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "冻结失败，该会员不存在" });
            }
            else if (result == 2)//成功
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "解冻成功", Data = "/admin/Member/MemberList" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "解冻失败", Data = "/admin/Member/MemberList" });

        }
        public ActionResult Close(long id)
        {
            int result = MemberService.Close(id);
            if (result == 0)//不存在
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "冻结失败，该会员不存在" });
            }
            else if (result == 2)//成功
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "冻结成功", Data = "/admin/Member/MemberList" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "解冻失败", Data = "/admin/Member/MemberList" });
        }
        /// <summary>
        /// PersonalData 控制器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PersonalData(int id)
        {
            MemberListViewModel model = new MemberListViewModel(); 
            model.MemberList = MemberService.ToUser(id).MemberList; 
            return View(model);
        }
        public ActionResult PersonalData_UpdateData( int id, string txtTrueName, string txtIdenCode, string txtPhoneNum)
        {
            MemberListViewModel model = new MemberListViewModel();
            model.MemberList = MemberService.ToUser(id).MemberList;
            MemberListDTO MemberList = new MemberListDTO();
            MemberList = model.MemberList.First();
            MemberList.TrueName = txtTrueName;
            MemberList.IdenCode = txtIdenCode;
            MemberList.PhoneNum = txtPhoneNum;
            int i = MemberService.Update_Date(MemberList);
            if (i>0)
            {
                return Json(new AjaxResult { Status = "1", Msg = "修改成功", Data = "/admin/Member/PersonalData?id="+ id + "" });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "修改失败", Data = "/admin/Member/PersonalData?id=" + id + "" });
            } 
        }
        public ActionResult Update_Password(int id)
        {
            MemberListViewModel model = new MemberListViewModel();
            model.MemberList = MemberService.ToUser(id).MemberList;
            MemberListDTO MemberList = new MemberListDTO();
            MemberList = model.MemberList.First();
            MemberList.Password = CommonHelper.GetMD5("111111");
            MemberList.SecondPassword = CommonHelper.GetMD5("111111"); ;
            MemberList.ThreePassword = CommonHelper.GetMD5("111111"); ;
            int i = MemberService.Update_Date(MemberList);
            if (i > 0)
            {
                return Json(new AjaxResult { Status = "1", Msg = "密码修改成功", Data = "/admin/Member/PersonalData?id=" + id + "" });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "密码修改失败", Data = "/admin/Member/PersonalData?id=" + id + "" });
            }
        }

    }
}