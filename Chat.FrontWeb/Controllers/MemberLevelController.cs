using SDMS.DTO.DTO;
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.MemberLevel;
using SDMS.IService.Interface;
using SDMS.Service.Service;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SDMS.Web.Controllers
{
    public class MemberLevelController : FrontBaseController
    {
        public IGlobeParamService GlobeParamService { get; set; }
        public ILevelService Level { get; set; }
        public IMemberService Member { get; set; }
        public IMemberLevelService MemberLevelService { get; set; }
        public IAgentServeice AgentServeice { get; set; }
        // GET: MemberLevel

        /// <summary>
        /// MemberLevel控制器
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberLevel()
        {
         
            GlobeParamDTO GlobeParam = new GlobeParamDTO();
            MemberLevelListViewModel Model = new MemberLevelListViewModel();
            //GlobeParam = GlobeParamService.GetByName("1");
            Model.UserPro = MemberLevelService.GetUserPro((int)GetLoginID()).UserPro;
            Model.MemberListDTO = Member.ToUser((int)GetLoginID()).MemberList.First();
            Model.BlogCategory = Level.GetAll();
            return View(Model);
        }
        /// <summary>
        /// 选择等级取差额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MemberLevel_Change(int id)
        {
            MemberLevelListViewModel model = new MemberLevelListViewModel();
            shengji shengji = new shengji();
            model.MemberListDTO = Member.ToUser((int)GetLoginID()).MemberList.First();//查这个人的ID信息
            if (id == 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择等级" });
            }
            if (id <= model.MemberListDTO.LevelID)
            {
                return Json(new AjaxResult { Status = "0", Msg = "选取的等级不能小于当前等级" });
            }
            
            if (id > model.MemberListDTO.LevelID)
            {
                GlobeParamDTO GlobeParam = new GlobeParamDTO();
                GlobeParam = GlobeParamService.GetByName("Level"+id);
                if (GlobeParam == null)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "后台参数设置错误" });
                }
                decimal a;
                if (!decimal.TryParse(GlobeParam.ParamVarchar, out a))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "数值类型无效" });
                }

                shengji.shengji_Left = model.MemberListDTO.RegMoney;
                shengji.shengji_right = a;
                shengji.balance = shengji.shengji_right - shengji.shengji_Left;
                model.shengji = shengji;
                if (model.MemberListDTO.Emoney <shengji.balance)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "余额不足，请充值后再注册" });
                }
                return Json(new AjaxResult { Status = "1", Data = model });
            }

            return Json(new AjaxResult { Status = "1", Data = model });
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MemberLevel_btn(int id) //还差钱没扣
        {
            MemberLevelListViewModel model = new MemberLevelListViewModel();
            shengji shengji = new shengji();
            MemberListDTO User = new MemberListDTO();
            model.MemberListDTO = Member.ToUser((int)GetLoginID()).MemberList.First();//查这个人的ID信息
            if (id == 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择等级" });
            }
            if (id <= model.MemberListDTO.LevelID)
            {
                return Json(new AjaxResult { Status = "0", Msg = "选取的等级不能小于当前等级" });
            }
            if (id > model.MemberListDTO.LevelID)
            {
                //GlobeParamDTO GlobeParam = new GlobeParamDTO();
                //GlobeParam = GlobeParamService.GetByName("Level" + model.MemberListDTO.LevelID);
                //if (GlobeParam == null)
                //{
                //    return Json(new AjaxResult { Status = "0", Msg = "后台参数设置错误" });
                //}
                GlobeParamDTO GlobeParam = new GlobeParamDTO();
                GlobeParam = GlobeParamService.GetByName("Level" + id);
                if (GlobeParam == null)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "后台参数设置错误" });
                }
                decimal a;
                if (!decimal.TryParse(GlobeParam.ParamVarchar, out a))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "数值类型无效" });
                } 
                shengji.shengji_Left = model.MemberListDTO.RegMoney;
                shengji.shengji_right = a;
                shengji.balance = shengji.shengji_right - shengji.shengji_Left;
                model.shengji = shengji;

                if (model.MemberListDTO.Emoney < shengji.balance)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "余额不足，请充值后再注册" });
                }

                UserProDTO UserPro = new UserProDTO();
                UserPro.AddDate = DateTime.Now;
                UserPro.CreateTime = DateTime.Now;
                UserPro.Flag = 1;
                UserPro.FlagDate = DateTime.Now;
                UserPro.LastLevel = model.MemberListDTO.LevelID;
                UserPro.EndLevel = id;
                UserPro.Pro001 = 0;
                UserPro.ProMoney = a;
                UserPro.Remark = "前台升级";
                UserPro.UserID = GetLoginID();
                long i = 0;
                long b = 0;

                
                //try
                //{

                //}
                //catch (Exception)
                //{

                //}
                i = MemberLevelService.Add(UserPro);
                b = Member.Update_LeveID((int)GetLoginID(), id, shengji.balance);

                if (i > 0 && b > 0)
                {
                    return Json(new AjaxResult { Status = "1", Msg = "升级成功" });
                }
                else
                {
                    return Json(new AjaxResult { Status = "0", Msg = "升级失败" });
                }
            }
            return Json(new AjaxResult { Status = "0", Msg = "升级失败" });
        }
        /// <summary>
        /// AgentLevel的控制器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult AgentLevel(string name = "system") //还差钱没扣
        {
            AgentListViewModel model = new AgentListViewModel();
           
            model.Member = Member.ToUser((int)GetLoginID()).MemberList.First();//查询这个人的信息 ，只要GetUserInfo().UserCode
            if (AgentServeice.GetAgentName(name).AgentList.Length<=0)
            {
                return View(model);
            }  
            else 
            {
                model.AgentList = AgentServeice.GetAgentName(name).AgentList.First(); ;
                return View(model);
            }
           
         
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Agent_btn(int id) //提交
        {
            //先查有没有数据 在查是否为待激活状态 ，激活状态，然后在插入申请
            AgentListViewModel model = new AgentListViewModel();
            AgentListDTO Agent = new AgentListDTO();
            model.Agent = AgentServeice.GetAgentName(GetUserInfo().UserCode).AgentList;
            if (model.Agent.Length>0)
            {
                model.AgentList = model.Agent.First();
                if (model.AgentList.AgentType!=2)
                {
                    return Json(new AjaxResult { Status = "1", Msg = "提交的申请未审批,请耐心等待" });
                }
                return Json(new AjaxResult { Status = "1", Msg = "该报单中心已存在" });
            }
            Agent.AgentCode = GetUserInfo().UserCode;
            Agent.Flag = 0;//等待审核
            Agent.UserID = GetLoginID();
            Agent.AgentType = 1; 
            Agent.CreateTime = DateTime.Now;
            long i =  AgentServeice.Add(Agent);
            if (i>0)
            {
                return Json(new AjaxResult { Status = "1", Msg = "申请成功" });
            } 
            return Json(new AjaxResult { Status = "0", Msg = "申请失败" });
        }
        /// <summary>
        /// 查询状态--表内有数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetAgentState(int id) //还差钱没扣,还要查询一下状态
        {
            AgentListViewModel model = new AgentListViewModel();
            AgentListDTO Agent = new AgentListDTO();
            model.Agent = AgentServeice.GetAgentName(GetUserInfo().UserCode).AgentList;
            if (model.Agent.Length>0)
            {
                model.AgentList = model.Agent.First();
                if (model.AgentList.Flag == 0)
                {
                    return Json(new AjaxResult { Status = "1", Msg = "提交的申请未审批,请耐心等待" });
                }
                else if (model.AgentList.Flag == 1)
                {
                    return Json(new AjaxResult { Status = "1", Msg = "当前已经是报单中心" });
                }
                else if (model.AgentList.Flag == 2)
                {
                    return Json(new AjaxResult { Status = "1", Msg = "当前报单中心已被冻结" });
                }
            } 

            return Json(new AjaxResult { Status = "1", Msg = "您还不是报单中心" });
        }
        /// <summary>
        /// 查询状态--表内无数据，则显示Member表的GetUserInfo().UserCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetAgentState_Member(int id) //还差钱没扣
        { 
            return Json(new AjaxResult { Status = "1", Msg = "您还不是报单中心" });
        }
    }
}