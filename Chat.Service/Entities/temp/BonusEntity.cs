using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class BonusEntity//:BaseEntity
    {
        public long UserID { get; set; }
        public long TypeID { get; set; }
        public decimal Amount { get; set; }
        public decimal Revenue { get; set; }
        public decimal Sf { get; set; }
        public DateTime AddTime { get; set; }
        public int IsSettled { get; set; }
        public string Source { get; set; }
        public string SourceEn { get; set; }
        public DateTime? SttleTime { get; set; }
        public int? FromUserID { get; set; }
        public int? Bonus001 { get; set; }
        public int? Bonus002 { get; set; }
        public string Bonus003 { get; set; }
        public string Bonus004 { get; set; }
        public decimal? Bonus005 { get; set; }
        public decimal? Bonus006 { get; set; }
        public DateTime? Bonus007 { get; set; }
        //public virtual UserEntity Users { get; set; }
        public virtual BonusTypeEntity BonusTypes { get; set; }
    }
}
