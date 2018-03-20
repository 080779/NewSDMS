using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.Member
{
    public class MemberListViewModel
    {
        public MemberListDTO[] MemberList { get; set; }
        public string Page { get; set; }
        public LevelDTO[] BlogCategory { get; set; }
        public MemberDTO[] MemberDTO { get; set; }

    }
    /// <summary>
    /// 获取等级 
    /// </summary>
    public class BlogCategory
    {
        public int LevelID { get; set; }
        public string LevelName { get; set; }

    }
}