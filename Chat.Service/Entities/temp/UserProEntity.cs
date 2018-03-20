using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class UserProEntity//:BaseEntity
    {
        public long UserID { get; set; }
        public int LastLevel { get; set; }
        public int EndLevel { get; set; }
        public decimal? ProMoney { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? FlagDate { get; set; }
        public string Remark { get; set; }
        public int Flag { get; set; }
        public int? Pro001 { get; set; }
        public int? Pro002 { get; set; }
        public decimal? Pro003 { get; set; }
        public decimal? Pro004 { get; set; }
        public decimal? Pro005 { get; set; }
        public string Pro006 { get; set; }
        public string Pro007 { get; set; }
        public string Pro008 { get; set; }
    }
}
