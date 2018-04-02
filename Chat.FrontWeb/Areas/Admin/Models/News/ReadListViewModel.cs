using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.News
{
    public class ReadListViewModel
    {
        public ReadNumberDTO[] ReadNumbers { get; set; }
        public string Page { get; set; }
    }
}