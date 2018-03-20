using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDMS.DTO.DTO;
using SDMS.Web.Areas.Admin.Models.Finance;
using SDMS.IService.Interface;
using SDMS.Common;
using SDMS.Web.Areas.Admin.Controllers.Base;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class FinanceController : AdminBaseController
    {
        public IRemitService remitService { get; set; }
        public ITakeMoneyService takemoneyService { get; set; }
        public IRechargeService rechargeService { get; set; }
        public ICurrencyNameService currencynameService { get; set; }
        public IUserService userService { get; set; }
        public IBonusService bonusService { get; set; }
        public IBonusTypeService bonustypeService { get; set; }
        public IJournalService journalService { get; set; }
        public IChangeService changeService { get; set; }
        public IChangeTypeService changetypeService { get; set; }

        int PageSize = 10;
        // GET: Admin/Finance
        public ActionResult Index(int pageIndex = 1)
        {
            return View();
        }

        #region 充值管理
        public ActionResult RemitList()
        {
            RemitListModel model = new RemitListModel();
            
            RemitPageResult rpModel = new RemitPageResult();
            //查询数据
            rpModel = remitService.GetPageList(0, "", "", -1, null, null, 1, PageSize);
            model.remitList = rpModel.Remits;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = rpModel.TotalCount;

            if (rpModel.TotalCount <= PageSize)
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
        public ActionResult RemitList(string usercode, string truename, DateTime? start, DateTime? end, int state = -1, int pageIndex = 1)
        {
            RemitListModel model = new RemitListModel();
            
            RemitPageResult rpModel = new RemitPageResult();
            //查询数据

            rpModel = remitService.GetPageList(0, usercode, truename, state, start, end, pageIndex, PageSize);
            model.remitList = rpModel.Remits;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = rpModel.TotalCount;

            if (rpModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RemitDel(long ID)
        {
            int t = remitService.Del(ID);
            if (t == 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/admin/finance/remitList" });
            }
            else if (t == 1)
                return Json(new AjaxResult { Status = "0", Msg = "删除失败！" });
            else
                return Json(new AjaxResult { Status = "0", Msg = "已删除！" });
        }

        /// <summary>
        /// 确认记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RemitUpdateState(long ID)
        {
            int t = remitService.UpdateState(ID, 1);
            if (t == 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/admin/finance/remitList" });
            }
            else if (t == 1)
                return Json(new AjaxResult { Status = "0", Msg = "确认失败！" });
            else if (t == 2)
                return Json(new AjaxResult { Status = "0", Msg = "已删除！" });
            else
                return Json(new AjaxResult { Status = "0", Msg = "已确认！" });
        }
        #endregion

        #region 提现管理
        public ActionResult TakeMoneyList()
        {
            TakeMoneyListModel model = new TakeMoneyListModel();
            
            //查询数据
            TakeMoneyPageResult takeModel = new TakeMoneyPageResult();
            takeModel = takemoneyService.GetPageList(0, "", "", -1, null, null, 1, PageSize);

            model.takemoneyList = takeModel.TakeMoneys;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = takeModel.TotalCount;

            if (takeModel.TotalCount <= PageSize)
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
        public ActionResult TakeMoneyList(string usercode, string truename, DateTime? start, DateTime? end, int state = -1, int pageIndex = 1)
        {
            TakeMoneyListModel model = new TakeMoneyListModel();
            
            TakeMoneyPageResult takeModel = new TakeMoneyPageResult();
            //查询数据

            takeModel = takemoneyService.GetPageList(0, usercode, truename, state, start, end, pageIndex, PageSize);
            model.takemoneyList = takeModel.TakeMoneys;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = takeModel.TotalCount;

            if (takeModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult TakeMoneyDel(long ID, int PageIndex)
        {
            int t = takemoneyService.Del(ID);
            if (t == 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/admin/finance/takemoneyList?pageindex" + PageIndex });
            }
            else if (t == 1)
                return Json(new AjaxResult { Status = "0", Msg = "删除失败！" });
            else
                return Json(new AjaxResult { Status = "0", Msg = "已删除！" });
        }

        /// <summary>
        /// 确认记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult TakeMoneyUpdateFlag(long ID, int PageIndex)
        {
            int t = takemoneyService.UpdateFlag(ID, 1);
            if (t == 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/admin/finance/takemoneyList?" + PageIndex });
            }
            else if (t == 1)
                return Json(new AjaxResult { Status = "0", Msg = "确认失败！" });
            else if (t == 2)
                return Json(new AjaxResult { Status = "0", Msg = "已删除！" });
            else
                return Json(new AjaxResult { Status = "0", Msg = "已确认！" });
        }
        #endregion

        #region 后台充值列表
        /// <summary>
        /// 后台充值列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RechargeList()
        {
            RechargeListModel model = new RechargeListModel();
            
            //查询数据
            RechargePageResult rechargeModel = new RechargePageResult();
            rechargeModel = rechargeService.GetPageList(0, "", "", 0, 0, null, null, 1, PageSize);

            model.rechargeList = rechargeModel.Recharges;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = rechargeModel.TotalCount;

            if (rechargeModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            //币种
            model.currencyList = currencynameService.GetList();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(model.currencyList, "ID", "CurrencyName");
            selectItemList.AddRange(selectList);
            ViewBag.currency = selectItemList;

            return View(model);
        }

        /// <summary>
        /// 后台充值列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RechargeList(string usercode, string truename, DateTime? start, DateTime? end, int type = 0, int style = 0, int pageIndex = 1)
        {
            RechargeListModel model = new RechargeListModel();
            
            //查询数据
            RechargePageResult rechargeModel = new RechargePageResult();
            rechargeModel = rechargeService.GetPageList(0, usercode, truename, type, style, start, end, pageIndex, PageSize);

            model.rechargeList = rechargeModel.Recharges;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = rechargeModel.TotalCount;

            if (rechargeModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }

            return Json(new AjaxResult { Status = "1", Data = model });
        }


        public ActionResult AddMoney(string UserCode, int Type, int Style, string strAmount)
        {
            if (string.IsNullOrEmpty(UserCode))
            {
                return Json(new AjaxResult { Status = "0", Msg = "会员编号不能为空" });
            }
            if (Type <= 0)//币种
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择充值币种" });
            }
            if (Style <= 0)//类型
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择充值类型" });
            }
            decimal Amount = 0;
            if(!decimal.TryParse(strAmount, out Amount))
            {
                return Json(new AjaxResult { Status = "0", Msg = "请输入有效金额" });
            }
            UserDTO udto = userService.GetModelCode(UserCode);
            if(udto == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "输入的会员编号不存在" });
            }
            decimal balance = 0;
            if(Style == 1)//增加
            {
                if (Type == 1)
                {
                    balance = udto.BonusAccount + Amount;
                }
            }
            else//减少
            {
                if (Type == 1)
                {
                    balance = udto.BonusAccount - Amount;
                }
            }
            
            long id = rechargeService.Add(udto.ID, Amount, balance, Type, Style);
            if(id > 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/admin/finance/rechargeList" });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "操作失败" });
            }
        }
        #endregion

        #region 奖金明细
        /// <summary>
        /// 奖金明细列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BonusList()
        {
            BonusListModel model = new BonusListModel();
            
            //查询数据
            BonusPageResult bonusModel = new BonusPageResult();
            bonusModel = bonusService.GetPageList(0, "", "", 0, null, null, 1, PageSize);

            model.bonusList = bonusModel.BonusS;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = bonusModel.TotalCount;

            if (bonusModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            //币种
            model.bonusTypeList = bonustypeService.GetList();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(model.bonusTypeList, "ID", "TypeName");
            selectItemList.AddRange(selectList);
            ViewBag.bonustype = selectItemList;

            return View(model);
        }

        /// <summary>
        /// 后台充值列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BonusList(string usercode, string truename, DateTime? start, DateTime? end, int type = 0, int pageIndex = 1)
        {
            BonusListModel model = new BonusListModel();
            
            //查询数据
            BonusPageResult bonusModel = new BonusPageResult();
            bonusModel = bonusService.GetPageList(0, usercode, truename, type, start, end, pageIndex, PageSize);

            model.bonusList = bonusModel.BonusS;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = bonusModel.TotalCount;

            if (bonusModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }

            return Json(new AjaxResult { Status = "1", Data = model });
        }
        #endregion

        #region 账户明细列表
        /// <summary>
        /// 账户明细列表
        /// </summary>
        /// <returns></returns>
        public ActionResult JournalList()
        {
            JournalListModel model = new JournalListModel();
            
            //查询数据
            JournalPageResult journalModel = new JournalPageResult();
            journalModel = journalService.GetPageList(0, "", "", 0, null, null, 1, PageSize);

            model.journalList = journalModel.Journals;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = journalModel.TotalCount;

            if (journalModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            //币种
            model.currencyList = currencynameService.GetList();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(model.currencyList, "ID", "CurrencyName");
            selectItemList.AddRange(selectList);
            ViewBag.currency = selectItemList;

            return View(model);
        }

        /// <summary>
        /// 账户明细列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult JournalList(string usercode, string truename, DateTime? start, DateTime? end, int type = 0, int pageIndex = 1)
        {
            JournalListModel model = new JournalListModel();
            
            //账户明细列表
            JournalPageResult journalModel = new JournalPageResult();
            journalModel = journalService.GetPageList(0, usercode, truename, type, start, end, pageIndex, PageSize);

            model.journalList = journalModel.Journals;
            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = journalModel.TotalCount;

            if (journalModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }

            return Json(new AjaxResult { Status = "1", Data = model });
        }

        #endregion

        #region 转账
        
        public ActionResult ChangeList()
        {
            ChangeListModel model = new ChangeListModel();

            ChangePageResult changeModel = new ChangePageResult();
            List<ChangeTypeDTO> dtolist = changetypeService.GetList();

            if (dtolist != null)
            {
                model.changeTypeList = dtolist;
            }

            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(model.changeTypeList, "ID", "TypeName");
            selectItemList.AddRange(selectList);
            ViewBag.changetype = selectItemList;

            //查询数据
            changeModel = changeService.GetPageList(0, "", "", 0, null, null, 1, PageSize);
            model.changeList = changeModel.ChangeList;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = 1;
            pager.PageSize = PageSize;
            pager.TotalCount = changeModel.TotalCount;

            if (changeModel.TotalCount <= PageSize)
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
        public ActionResult ChangeList(string usercode, string truename,long changetype, DateTime? start, DateTime? end, int pageIndex = 1)
        {
            ChangeListModel model = new ChangeListModel();

            ChangePageResult changeModel = new ChangePageResult();
            //查询数据
            changeModel = changeService.GetPageList(0, usercode, truename, changetype, start, end, pageIndex, PageSize);
            model.changeList = changeModel.ChangeList;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = PageSize;
            pager.TotalCount = changeModel.TotalCount;

            if (changeModel.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return Json(new AjaxResult { Status = "1", Data = model });
        }
        
        #endregion

    }
}