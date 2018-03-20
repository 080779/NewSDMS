using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class OrderEntity//:BaseEntity
    {
        public int OrderID { get; set; }
        public long UserID { get; set; }
        public string OrderCode { get; set; }
        public string UserAddr { get; set; }
        public int OrderSum { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal PVTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public int IsSend { get; set; }
        public int PayMethod { get; set; }
        public int? OrderType { get; set; }
        public decimal? order1 { get; set; }
        public decimal? order2 { get; set; }
        public string order3 { get; set; }
        public string order4 { get; set; }
        public string Consignee { get; set; }
        public string Phone { get; set; }
        public string ConsigneeName { get; set; }
    }
}
