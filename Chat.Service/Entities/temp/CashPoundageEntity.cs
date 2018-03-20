using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class CashPoundageEntity//:BaseEntity
    {
        public int? UserID { get; set; }
        public decimal? Amount { get; set; }
        public int? Flag { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? SettleTime { get; set; }
    }
}
