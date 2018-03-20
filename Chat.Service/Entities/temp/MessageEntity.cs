using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDMS.Service.Entities
{    
    public class MessageEntity//:BaseEntity
    {
        public int MID { get; set; }
        public int? Userid { get; set; }
        public string MobileNum { get; set; }
        public string Mcontent { get; set; }
        public DateTime? SendTime { get; set; }
        public string Flag { get; set; }
    }
}
