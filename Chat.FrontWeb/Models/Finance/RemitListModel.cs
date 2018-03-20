using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Models.Finance
{
    public class RemitListModel
    {
        public RemitDTO[] remitList { get; set; }
        public string Page { get; set; }
    }
}