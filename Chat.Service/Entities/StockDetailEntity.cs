using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class StockDetailEntity:BaseEntity
    {
        public int StockDetailID { get; set; }
        public int StockID { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public int Periods { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
