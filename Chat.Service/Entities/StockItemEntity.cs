using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class StockItemEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 项目总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 项目总份数
        /// </summary>
        public long TotalCopies { get; set; }
        /// <summary>
        /// 发行份数
        /// </summary>
        public long IssueCopies { get; set; }
        /// <summary>
        /// 每份单价
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
