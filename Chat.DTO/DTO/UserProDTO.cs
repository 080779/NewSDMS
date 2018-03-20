using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class UserProDTO : BaseDTO
    {
        public long UserID { get; set; }
        public int LastLevel { get; set; }
        public int EndLevel { get; set; }
        public decimal? ProMoney { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? FlagDate { get; set; }
        public string Remark { get; set; }
        public int Flag { get; set; }
        public int? Pro001 { get; set; } //（1）前台（0）后台的意思
        public string UserCode { get; set; }
        public string TrueName { get; set; }
        public string LastLevelName { get; set; }
        public string EndLevelName  { get; set; }
}
}
