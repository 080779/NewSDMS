using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models.Agent;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class AgentController : AdminBaseController
    {
        // GET: Admin/Agent
        public IAgentServeice agentServeice { get; set; }
        public int pageSize = 1;
        
        public ActionResult Agent(int pageIndex = 1)
        {
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
            }; 
            return View();
        }
        public PartialViewResult Agent_Page(string Id, string usercode, DateTime? Strat, DateTime? End, int i, int pageIndex = 1)
        {
            AgentListViewModel model = new AgentListViewModel();
            AgentSearchResult result = agentServeice.GetAgentList(Id, usercode, Strat, End, pageIndex, pageSize, i);
            model.AgentListDTO = result.AgentList;
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
            string Table = "";
            if (i == 0)
            {
                Table = "AgentPage";
            }
            else
            {
                Table = "AgentListPage";
            }
            return PartialView(Table, model);
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
        public PartialViewResult MemberGetPage(string Id, string usercode, DateTime? Strat, DateTime? End, int i,  int pageIndex = 1 )
        {
         
            AgentListViewModel model = new AgentListViewModel();
            AgentSearchResult result = agentServeice.GetAgentList(Id, usercode, Strat, End, pageIndex, pageSize, i);
            model.AgentListDTO = result.AgentList; 
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
            string Table = "";
            if (i==0)
            {
                Table = "AgentPage";
            }
           else  
            {
                Table = "AgentListPage";
            }
            return PartialView(Table, model);
            //return Json(new AjaxResult { Status = "1", Data = model });
        }
        public ActionResult Pass(long id)
        {
            int result = agentServeice.Pass(id);
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
                return Json(new AjaxResult { Status = result.ToString(), Msg = "激活成功", Data = "/admin/agent/agent" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "激活成功", Data = "/admin/agent/agent" });

        }
        public ActionResult Del(long id)
        {
            int result = agentServeice.Del(id);
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
                return Json(new AjaxResult { Status = result.ToString(), Msg = "删除成功", Data = "/admin/agent/agent" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "删除成功", Data = "/admin/agent/agent" });
        }
        ////-------------------------------------------------------------------
        public ActionResult AgentList(int pageIndex = 1)
        {
         
            ViewBag.hard_value = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="--请选择--"},
                new SelectListItem(){Value="1",Text="会员编号"},
            }; 
            return View();
        }

        public ActionResult Open(long id)
        {
            int result = agentServeice.Open(id);
            if (result == 0)//不存在
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "冻结失败，该会员不存在" });
            }
            else if (result == 2)//成功
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "解冻成功", Data = "/admin/agent/agentlist" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "解冻失败", Data = "/admin/agent/agentlist" });

        }
        public ActionResult Close(long id)
        {
            int result = agentServeice.Close(id);
            if (result == 0)//不存在
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "冻结失败，该会员不存在" });
            }
            else if (result == 2)//成功
            {
                return Json(new AjaxResult { Status = result.ToString(), Msg = "冻结成功", Data = "/admin/agent/agentlist" });
            }

            return Json(new AjaxResult { Status = result.ToString(), Msg = "解冻失败", Data = "/admin/agent/agentlist" });
        }
        public ActionResult Pic1()
        {
          
            string a=  agentServeice.pic_data();
         
            return Json(new AjaxResult { Status = a.ToString(), Msg = "查询成功", Data = "/admin/agent/agentlist" });
        }
        public ActionResult Pic()
        { 
            return View();
        }
    }
}