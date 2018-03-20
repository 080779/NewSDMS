using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SDMS.Web.Areas.Admin.Models.Message
{
    public class LeaveReMsgListModel
    {
        public LeaveReMsgDTO[] leaveReMsgList { get; set; }
        public string Page { get; set; }
    }
}