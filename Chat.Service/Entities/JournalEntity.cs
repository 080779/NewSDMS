using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class JournalEntity:BaseEntity
    {
        public long? UserID { get; set; }
        public string Remark { get; set; }
        public string RemarkEn { get; set; }
        public decimal? InAmount { get; set; }
        public decimal? OutAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public DateTime? JournalDate { get; set; }
        public long? JournalType { get; set; }
        public long Journal01 { get; set; }
        public int? Journal02 { get; set; }
        public string Journal03 { get; set; }
        public string Journal04 { get; set; }
        public decimal? Journal05 { get; set; }
        public decimal? Journal06 { get; set; }
        public DateTime? Journal07 { get; set; }
        //public virtual UserEntity Users { get; set; }
        public virtual CurrencyNameEntity Currencys { get; set; }
    }
}
