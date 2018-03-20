using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.System
{
    public class RoleEditViewModel
    {
        public RoleDTO Role { get; set; }
        public List<Permissions> PermissionList { get; set; }
        public List<long> PermissionIds { get; set; }
    }
}