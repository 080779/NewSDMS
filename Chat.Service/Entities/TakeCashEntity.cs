using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class TakeCashEntity:BaseEntity
    {
        /// <summary>
        /// 提现金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 提现手续费
        /// </summary>
        public decimal Poundage { get; set; } = 0;
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
        public long StateId { get; set; }
        public virtual TakeCashStateEntity State { get; set; }
        public virtual HolderEntity Holder { get; set; }
        public long HolderId { get; set; }
    }
}
