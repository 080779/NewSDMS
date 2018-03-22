using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.Model
{
    public class HolderSvcModel
    {
        public long Id { get; set; }
        /// <summary>
        /// 股票项目Id
        /// </summary>
        public long StockItemId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
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
        /// 本金占股比例
        /// </summary>
        public decimal Proportion { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 交易密码
        /// </summary>
        public string TradePassword { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Contact { get; set; }

        public bool Flag { get; set; }
    }
}
