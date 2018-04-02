using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class HolderDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public bool Gender { get; set; }
        public string OpenId { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 分红提现账号
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 银行名
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 客户的总资产
        /// </summary>
        public decimal TotalAssets { get; set; }
        /// <summary>
        /// 本金
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 认购份数
        /// </summary>
        public long Copies { get; set; }
        /// <summary>
        /// 累计分红
        /// </summary>
        public decimal TotalBonus { get; set; }
        /// <summary>
        /// 本金占股比例
        /// </summary>
        public decimal Proportion { get; set; }
        /// <summary>
        /// 可提现分红
        /// </summary>
        public decimal TakeBonus { get; set; }
        /// <summary>
        /// 已提现分红
        /// </summary>
        public decimal HaveBonus { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 紧急联系人姓名
        /// </summary>
        public string UrgencyName { get; set; }
        /// <summary>
        /// 紧急联系人电话
        /// </summary>
        public string UrgencyContact { get; set; }
        public DateTime TakeCashTime { get; set; }
        /// <summary>
        /// 交易密码
        /// </summary>
        public string TradePassword { get; set; }
        /// <summary>
        /// 微信头像，从授权后保存到seession中
        /// </summary>
        public string HeadImgUrl { get; set; }
    }

    public class HolderCalcNumberDTO
    {
        /// <summary>
        /// 股东的总人数
        /// </summary>
        public long TotalHolder { get; set; }
        /// <summary>
        /// 所有股东的本金总额
        /// </summary>
        public decimal TotalHolderAmount { get; set; }
        /// <summary>
        /// 所有股东的累计分红总额
        /// </summary>
        public decimal TotalHolderBonus { get; set; }
        /// <summary>
        /// 所有股东的占股比例总数
        /// </summary>
        public decimal TotalProportion { get; set; }
    }

    public class TakeCashCalcNumberDTO
    {
        /// <summary>
        /// 总分红金额
        /// </summary>
        public decimal TotalBonusNumber { get; set; }
        /// <summary>
        /// 总可提现金额
        /// </summary>
        public decimal TotalTakeBonus { get; set; }
        /// <summary>
        /// 总已提现金额
        /// </summary>
        public decimal TotalHaveBonus { get; set; }
    }
}
