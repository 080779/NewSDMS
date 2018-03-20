using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class RemitEntity:BaseEntity
    {
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountUser { get; set; }
        public DateTime? RechargeableDate { get; set; }
        public DateTime? AddDate { get; set; }
        public int? State { get; set; }
        public decimal? RemitMoney { get; set; }
        public decimal? YuAmount { get; set; }
        public string Remark { get; set; }
        public long? UserID { get; set; }
        public DateTime? PassDate { get; set; }
        public int? Remit001 { get; set; }
        public int? Remit002 { get; set; }
        public string OutBankName { get; set; }
        public string OutBankAccount { get; set; }
        public decimal? Remit005 { get; set; }
        public decimal? Remit006 { get; set; }
        public string OutBankAccountUser { get; set; }
        public virtual UserEntity Users { get; set; }
    }
}
