using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class StockItem//:BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// 项目的总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 总份数
        /// </summary>
        public long Number { get; set; }
        /// <summary>
        /// 每份单价
        /// </summary>
        public decimal Price { get; set; }
    }
}
