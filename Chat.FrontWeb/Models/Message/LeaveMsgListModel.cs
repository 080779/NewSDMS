using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SDMS.Web.Models.Member
{
    public class LeaveMsgListModel
    {
        public LeaveMsgDTO[] leaveMsgList { get; set; }
        public string Page { get; set; }
    }
}