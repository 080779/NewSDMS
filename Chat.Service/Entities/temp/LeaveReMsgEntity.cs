using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public partial class LeaveReMsgEntity//:BaseEntity
    {
        public long LeaveID { get; set; }
        public string ReContent { get; set; }
        public System.DateTime ReTime { get; set; }
        public int UserType { get; set; }
        public long UserID { get; set; }
        public string UserCode { get; set; }
    }
}
