using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models
{
    public class ParentModel
    {
        public PowerDTO Parent { get; set; }
        public PowerDTO[] Child { get; set; }
    }

    public class IndexViewModel
    {
        public List<ParentModel> MenuList { get; set; }
        public long Id { get; set; }
    }
}