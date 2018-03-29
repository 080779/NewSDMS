using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.System
{
    public class AdminEditModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public long?[] RoleIds { get; set; }
    }
}