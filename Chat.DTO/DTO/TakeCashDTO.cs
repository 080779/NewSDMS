using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class TakeCashDTO:BaseDTO
    {
        /// <summary>
        /// 提现金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 提现手续费
        /// </summary>
        public decimal Poundage { get; set; }
        /// <summary>
        /// 提现消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 转账图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 是否成功提现
        /// </summary>
        public int Flag { get; set; }
        public long HolderId { get; set; }
        /// <summary>
        /// 股东名
        /// </summary>
        public string HolderName { get; set; }
        /// <summary>
        /// 股东银行账户
        /// </summary>
        public string HolderBankAccount { get; set; }
        /// <summary>
        /// 股东累计分红
        /// </summary>
        public decimal HolderTotalBonus { get; set; }
        /// <summary>
        /// 股东可提现分红
        /// </summary>
        public decimal HolderTakeBonus { get; set; }
        /// <summary>
        /// 股东已提现分红
        /// </summary>
        public decimal HolderHaveBonus { get; set; }
    }
}
