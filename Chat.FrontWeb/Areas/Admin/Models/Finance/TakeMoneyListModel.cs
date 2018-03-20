using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Areas.Admin.Models.Finance
{
    public class TakeMoneyListModel
    {
        public TakeMoneyDTO[] takemoneyList { get; set; }
        public string Page { get; set; }
    }
}