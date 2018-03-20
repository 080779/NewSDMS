using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class StockSplitEntity:BaseEntity
    {
        public int SplitID { get; set; }
        public decimal SplitPrice { get; set; }
        public decimal SplitPriceB { get; set; }
        public decimal SplitPriceL { get; set; }
        public string SplitRate { get; set; }
        public int SplitTimes { get; set; }
        public DateTime SplitDate { get; set; }
    }
}
