using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    /// <summary>
    /// 股东实体类
    /// </summary>
    public class HolderEntity:BaseEntity
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Mobile { get; set; }
        public string OpenId { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 分红提现账号
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 银行名
        /// </summary>
        public string BankName{ get; set; }
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
        public decimal TotalBonus { get; set; } = 0;
        /// <summary>
        /// 本金占股比例
        /// </summary>
        public decimal Proportion { get; set; }
        /// <summary>
        /// 可提现分红
        /// </summary>
        public decimal TakeBonus { get; set; } = 0;
        /// <summary>
        /// 已提现分红
        /// </summary>
        public decimal HaveBonus { get; set; } = 0;
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
        public string Password { get; set; }
        /// <summary>
        /// 交易密码
        /// </summary>
        public string TradePassword { get; set; }
        /// <summary>
        /// 认购的金额（本金已为认购金额）
        /// </summary>
        //public decimal BuyAmount { get; set; }
        //public long StockItemId { get; set; }
        //public virtual StockItemEntity StockItem { get; set; }
    }
}
