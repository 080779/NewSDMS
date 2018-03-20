using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class StockorderEntity//:BaseEntity
    {
        public long OrderID { get; set; }
        public long StockID { get; set; }
        public int UserID { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
    }
}
