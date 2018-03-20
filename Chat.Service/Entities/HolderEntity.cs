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
        public string Mobile { get; set; }
        /// <summary>
        /// 分红提现账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 客户的总资产
        /// </summary>
        public decimal TotalAssets { get; set; }
        /// <summary>
        /// 本金
        /// </summary>
        public decimal Amount { get; set; }
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
        /// 联系电话
        /// </summary>
        public string Contact { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 交易密码
        /// </summary>
        public string TradePassword { get; set; }
        /// <summary>
        /// 认购的金额
        /// </summary>
        public decimal BuyAmount { get; set; }
    }
}
