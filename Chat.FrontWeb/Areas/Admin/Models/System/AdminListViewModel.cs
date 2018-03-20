using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.System
{
    public class AdminListViewModel
    {
        public AdminListDTO[] AdminList { get; set; }
        public string Page { get; set; }
    }
}