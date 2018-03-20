using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public partial class CashorderEntity//:BaseEntity
    {
        public int OrderID { get; set; }
        public int CashbuyID { get; set; }
        public int CashsellID { get; set; }
        public int BUserID { get; set; }
        public int SUserID { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int BStatus { get; set; }
        public DateTime? PayDate { get; set; }
        public string BRemark { get; set; }
        public int SStatus { get; set; }
        public DateTime? SendDate { get; set; }
        public string SRemark { get; set; }
        public int Status { get; set; }
    }
}
