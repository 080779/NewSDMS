using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Areas.Admin.Models.System
{
    public class BankNameListModel
    {
        public List<BankNameDTO> bankList { get; set; }
    }
}