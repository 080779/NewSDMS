using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class RechargeEntity:BaseEntity
    {
        public long UserID { get; set; }
        public decimal? RechargeableMoney { get; set; }
        public int? RechargeStyle { get; set; }
        public int? Flag { get; set; }
        public DateTime? RechargeDate { get; set; }
        public decimal? YuAmount { get; set; }
        public long? RechargeType { get; set; }
        public int? AgentID { get; set; }
        public int? Recharge001 { get; set; }
        public int? Recharge002 { get; set; }
        public string Recharge003 { get; set; }
        public string Recharge004 { get; set; }
        public decimal? Recharge005 { get; set; }
        public decimal? Recharge006 { get; set; }
        public virtual UserEntity Users { get; set; }
        public virtual CurrencyNameEntity CurrencyNames { get; set; }
    }
}
