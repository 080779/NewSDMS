using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class StockLssueEntity:BaseEntity
    {
        public int IssueID { get; set; }
        public decimal IssueAmount { get; set; }
        public decimal SurplusAmount { get; set; }
        public decimal PaybackNum { get; set; }
        public decimal IssuePrice { get; set; }
        public int Periods { get; set; }
        public DateTime AddDate { get; set; }
        public int IsSell { get; set; }
    }
}
