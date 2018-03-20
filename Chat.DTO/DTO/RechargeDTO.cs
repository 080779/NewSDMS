using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SDMS.DTO.DTO
{
    public class RechargeDTO : BaseDTO
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
        public string UserCode { get; set; }
        public string TrueName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyNameEn { get; set; }
        public string StyleName { get; set; }
    }
}