using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.Holder
{
    public class HolderListViewModel
    {
        public HolderDTO[] Holders { get; set; }
        public string Page { get; set; }
    }
}