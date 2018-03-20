using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class TakeMoneyEntity//:BaseEntity
    {
        public DateTime? TakeTime { get; set; }
        public decimal TakeMoney { get; set; }
        public decimal TakePoundage { get; set; }
        public decimal RealityMoney { get; set; }
        public decimal BonusBalance { get; set; }
        public int Flag { get; set; }
        public long UserID { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountUser { get; set; }
        public string BankDian { get; set; }
        public int Take001 { get; set; }
        public int Take002 { get; set; }
        public string Take003 { get; set; }
        public string Take004 { get; set; }
        public decimal Take005 { get; set; }
        public DateTime? Take006 { get; set; }
        //public virtual UserEntity Users { get; set; }
    }
}
