using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class SMSEntity:BaseEntity
    {
        public long? ToUserID { get; set; }
        public string ToUserCode { get; set; }
        public string ToPhone { get; set; }
        public string SMSContent { get; set; }
        public DateTime? PublishTime { get; set; }
        public string SCode { get; set; }
        public DateTime? ValidTime { get; set; }
        public int? SendNum { get; set; }
        public int? IsValid { get; set; }
    }
}
