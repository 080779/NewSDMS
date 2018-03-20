using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SDMS.DTO.DTO;
using SDMS.Web.Models.Finance;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using SDMS.Common;
using SDMS.Web.Controllers.Base;

namespace CtrTemp.SDMS.Web.Controllers
{
    public class FinanceController : FrontBaseController
    {
        public IRemitService remitService { get; set; }
        public ITakeMoneyService takemoneyService { get; set; }
        public IRechargeService rechargeService { get; set; }
        public ICurrencyNameService currencynameService { get; set; }
        //public IUserService userService { get; set; }
        public IBonusService bonusService { get; set; }
        public IBonusTypeService bonustypeService { get; set; }
        public IJournalService journalService { get; set; }
        public IBankNameService banknameService { get; set; }
        public ISystemBankService sysbankService { get; set; }
        public IChangeService changeService { get; set; }
        public IChangeTypeService changetypeService { get; set; }

        private int PageSize = 10;

        // GET: Finance
        public ActionResult Index()
        {
            return View();
        }

        #region 提现
        public ActionResult TakeMoneyList()
        {
            TakeMoneyListModel model = new TakeMoneyListModel();
            
            //查询数据
            TakeMoneyPageResult takeModel = new TakeMoneyPageResult();
            takeModel = takemoneyService.GetPageList(GetLoginID(), "", "", -1, null, null, 1, PageSize);

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
        public ActionResult TakeMoneyList(DateTime? start, DateTime? end, int pageIndex = 1)
        {
            TakeMoneyListModel model = new TakeMoneyListModel();
            //查询数据
            TakeMoneyPageResult takeModel = new TakeMoneyPageResult();
            takeModel = takemoneyService.GetPageList(GetLoginID(), "", "", -1, null, null, 1, PageSize);

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

        public ActionResult AddTakeMoney()
        {
            TakeModel model = new TakeModel();
            model.chanyerate = Convert.ToDecimal(10) / 100;
            model.feerate = Convert.ToDecimal(5) / 100;
            model.mybonus = 10000;
            model.minmoney = 100;
            model.taketimes = 1;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddTakeMoney(decimal Amount)
        {
            if (Amount <= 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请输入大于0的金额" });
            }
            decimal cyRate = Convert.ToDecimal(10) / 100;
            decimal feeRate = Convert.ToDecimal(5)/100;
            decimal cy = Amount * cyRate;
            decimal fee = Amount * feeRate;
            UserDTO userModel = GetUserInfo();
            long iID = takemoneyService.Add(userModel.ID, Amount, cy, fee, 0, userModel.BankName, userModel.BankAccount, userModel.BankAccountUser);
            if (iID > 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/finance/takemoneyList" });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "提交失败" });
            }
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
                return Json(new AjaxResult { Status = "1", Data = "/finance/takemoneyList?pageindex" + PageIndex });
            }
            else if (t == 1)
                return Json(new AjaxResult { Status = "0", Msg = "删除失败！" });
            else
                return Json(new AjaxResult { Status = "0", Msg = "已删除！" });
        }
        #endregion
        
        #region 充值
        public ActionResult AddRemit()
        {
            RemitModel model = new RemitModel();
            model.bankoutList = banknameService.GetList();
            SystemBankDTO[] sysbankarr = sysbankService.GetList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            model.sysbankList = js.Serialize(sysbankarr);

            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(model.bankoutList, "ID", "BankName");
            selectItemList.AddRange(selectList);
            ViewBag.bankoutlist = selectItemList;
            //公司银行账户
            var selectItemList1 = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList1 = new SelectList(sysbankarr, "ID", "BankName");
            selectItemList1.AddRange(selectList1);
            ViewBag.bankinlist = selectItemList1;

            UserDTO userModel = GetUserInfo();
            if (userModel != null)
            {
                model.emoney = userModel.Emoney;
            }
            else
            {
                model.emoney = 0;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddRemit(decimal amount, long sysbankID, string bankname, string bankaccount, string bankaccountuser, DateTime? hkTime, string remark)
        {
            if (amount <= 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请输入大于0的金额" });
            }
            if (string.IsNullOrEmpty(bankname))
            {
                return Json(new AjaxResult { Status = "0", Msg = "请输入大于0的金额" });
            }
            //用户信息
            UserDTO userModel = GetUserInfo();
            //汇入账户
            SystemBankDTO sysdto = sysbankService.GetDTOByID(sysbankID);

            RemitDTO dto = new RemitDTO();
            dto.OutBankAccount = sysdto.BankAccount;
            dto.OutBankName = sysdto.BankName;
            dto.OutBankAccountUser = sysdto.BankAccountUser;
            dto.BankName = bankname;
            dto.BankAccount = bankaccount;
            dto.BankAccountUser = bankaccountuser;
            dto.RechargeableDate = hkTime;
            dto.Remark = remark;
            dto.State = 0;

            long iID = remitService.Add(dto);
            if (iID > 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/finance/remitList" });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "提交失败" });
            }
        }

        public ActionResult RemitList()
        {
            RemitListModel model = new RemitListModel();
            long iUserID = 9;
            RemitPageResult rpModel = new RemitPageResult();
            //查询数据
            rpModel = remitService.GetPageList(iUserID, "", "", -1, null, null, 1, PageSize);
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
        public ActionResult RemitList(DateTime? start, DateTime? end, int pageIndex = 1)
        {
            RemitListModel model = new RemitListModel();

            long iUserID = 9;
            RemitPageResult rpModel = new RemitPageResult();
            //查询数据
            rpModel = remitService.GetPageList(iUserID, "", "", -1, start, end, pageIndex, PageSize);
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
                return Json(new AjaxResult { Status = "1", Data = "/finance/remitList" });
            }
            else if (t == 1)
                return Json(new AjaxResult { Status = "0", Msg = "删除失败！" });
            else
                return Json(new AjaxResult { Status = "0", Msg = "已删除！" });
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
            journalModel = journalService.GetPageList(GetLoginID(), "", "", 0, null, null, 1, PageSize);

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
        public ActionResult JournalList(DateTime? start, DateTime? end, int type = 0, int pageIndex = 1)
        {
            JournalListModel model = new JournalListModel();
            //账户明细列表
            JournalPageResult journalModel = new JournalPageResult();
            journalModel = journalService.GetPageList(GetLoginID(), "", "", type, start, end, pageIndex, PageSize);

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
            bonusModel = bonusService.GetPageList(GetLoginID(), "", "", 0, null, null, 1, PageSize);

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
        public ActionResult BonusList(DateTime? start, DateTime? end, int type = 0, int pageIndex = 1)
        {
            BonusListModel model = new BonusListModel();
            
            //查询数据
            BonusPageResult bonusModel = new BonusPageResult();
            bonusModel = bonusService.GetPageList(GetLoginID(), "", "", type, start, end, pageIndex, PageSize);

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

        #region 转账
        public ActionResult AddChange()
        {
            ChangeModel model = new ChangeModel();
            List<ChangeTypeDTO> dtolist = changetypeService.GetList();
            if(dtolist != null)
            {
                model.changetypeList = dtolist;
            }
            
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(model.changetypeList, "ID", "TypeName");
            selectItemList.AddRange(selectList);
            ViewBag.dropchagelist = selectItemList;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AddChange(string tousercode,decimal amount, long changeType)
        {
            if (amount <= 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请输入大于0的金额" });
            }
            if(changeType == 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择转账类型" });
            }
            
            UserDTO Todto = userService.GetModelCode(tousercode);
            if (Todto == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "转账对象不存在" });
            }
            long iID = changeService.TransferMonbey(GetLoginID(), Todto.ID, amount, changeType,"","","","");
            if (iID > 0)
            {
                return Json(new AjaxResult { Status = "1", Data = "/finance/ChangeList" });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "提交失败" });
            }
        }

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
            changeModel = changeService.GetPageList(GetLoginID(), "", "", 0, null, null, 1, PageSize);
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
        public ActionResult ChangeList(long changeType,DateTime? start, DateTime? end, int pageIndex = 1)
        {
            ChangeListModel model = new ChangeListModel();

            ChangePageResult changeModel = new ChangePageResult();
            //查询数据
            changeModel = changeService.GetPageList(GetLoginID(), "", "", changeType, start, end, pageIndex, PageSize);
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

        public ActionResult GetTrueName(string UserCode)
        {
            UserDTO dto = userService.GetModelCode(UserCode);
            if (dto != null)
            {
                return Json(new AjaxResult { Status = "1", Data = dto.TrueName });
            }
            else
            {
                return Json(new AjaxResult { Status = "0", Msg = "会员编号不存在" });
            }
        }
        
        #endregion

    }
}