using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class SysLogEntity//:BaseEntity
    {
        public int? LogType { get; set; }
        public int? LogLeve { get; set; }
        public string LogCode { get; set; }
        public decimal? DataInt { get; set; }
        public string DataStr { get; set; }
        public string LogMsg { get; set; }
        public DateTime? LogDate { get; set; }
        public string Log1 { get; set; }
        public string Log2 { get; set; }
        public string Log3 { get; set; }
        public string Log4 { get; set; }
    }
}
