using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Areas.Admin.Models.Finance
{
    public class RechargeListModel
    {
        public RechargeDTO[] rechargeList { get; set; }
        public string Page { get; set; }
        public List<CurrencyNameDTO> currencyList { get; set; }
    }
}