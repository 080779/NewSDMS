using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public partial class LeaveMsgEntity:BaseEntity
    {
        public string MsgTitle { get; set; }
        public string MsgContent { get; set; }
        public System.DateTime LeaveTime { get; set; }
        public int IsRead { get; set; }
        public int IsReply { get; set; }
        public int FromUserType { get; set; }
        public Nullable<long> UserID { get; set; }
        public string UserCode { get; set; }
        public Nullable<int> FromIDIsDel { get; set; }
        public int ToUserType { get; set; }
        public Nullable<long> ToUserID { get; set; }
        public string ToUserCode { get; set; }
        public Nullable<int> ToIDIsDel { get; set; }
    }
}
