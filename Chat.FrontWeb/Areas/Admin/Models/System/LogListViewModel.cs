using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.System
{
    public class LogListViewModel
    {
        public AdminLogDTO[] AdminLogs { get; set; }
        public string Page { get; set; }
    }
}