using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class StockDTO
    {
        public long StockID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public int Surplus { get; set; }
        public int SplitNum { get; set; }
        public DateTime BuyDate { get; set; }
        public int IsLock { get; set; }
        public int IsSell { get; set; }
        public int SalesType { get; set; }
        public int IsBack { get; set; }
        public bool IsDeleted { set; get; }
        public DateTime CreateTime { set; get; }
        public string UserCode { set; get; }
    }
}
