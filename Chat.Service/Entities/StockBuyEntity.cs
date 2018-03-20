using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class StockBuyEntity:BaseEntity
    {
        public long StockBuyID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public decimal SurplusSum { get; set; }
        public DateTime BuyDate { get; set; }
        public int IsBuy { get; set; }
        public int Status { get; set; }
        public int IsBack { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public int IsOver { get; set; }
    }
}
