using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace SDMS.Web.Areas.Admin.Models.Finance
{
    public class AccountModel
    {
        public AccountDTO[] accountList { get; set; }
        public string Page { get; set; }
    }
}   