using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.Team
{
    public class UserProView
    {
        public List<UserProDTO> UserProViewList { set; get; }
        public int totalPage { set; get; }
        public int showPageNum { set; get; }
    }
}