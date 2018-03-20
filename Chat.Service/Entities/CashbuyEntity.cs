using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public  class CashbuyEntity:BaseEntity
    {
        public int CashbuyID { get; set; }
        public int CashsellID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public int BuyNum { get; set; }
        public DateTime BuyDate { get; set; }
        public int IsBuy { get; set; }
    }
}
