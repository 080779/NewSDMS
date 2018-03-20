using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class LeaveMsgDTO : BaseDTO
    {

    
        public string MsgTitle { get; set; }
        public string MsgContent { get; set; }
        public DateTime LeaveTime { get; set; }
        public int IsRead { get; set; }
        public int IsReply { get; set; }
        public string IsReplyName { get; set; }
        public int FromUserType { get; set; }
        public long UserID { get; set; }
        public string UserCode { get; set; }
        public int FromIDIsDel { get; set; }
        public int ToUserType { get; set; }
        public long ToUserID { get; set; }
        public string ToUserCode { get; set; }
        public int ToIDIsDel { get; set; }
        public bool IsDeleted { get; set; }
        public string LeaveOutName { get; set; }
        public string LeaveInName { get; set; }

    }
}
