using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class StockSplitDetailEntity:BaseEntity
    {
        public long SplitDetailID { get; set; }
        public int SplitID { get; set; }
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public int StockID { get; set; }
        public decimal SplitStockB { get; set; }
        public decimal SplitStockL { get; set; }
        public int SplitTimes { get; set; }
        public DateTime SplitDate { get; set; }
    }
}
