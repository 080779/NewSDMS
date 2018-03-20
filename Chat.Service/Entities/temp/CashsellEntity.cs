using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class CashsellEntity//:BaseEntity
    {
        public int CashsellID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public int UnitNum { get; set; }
        public int SaleNum { get; set; }
        public decimal Charge { get; set; }
        public DateTime SellDate { get; set; }
        public string Remark { get; set; }
        public int IsSell { get; set; }
        public int IsUndo { get; set; }
    }
}
