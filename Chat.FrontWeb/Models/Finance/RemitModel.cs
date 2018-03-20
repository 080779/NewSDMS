using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Models.Finance
{
    public class RemitModel
    {
        public decimal emoney { get; set; }
        public List<BankNameDTO> bankoutList { get; set; }
        public string sysbankList { get; set; }
    }
}