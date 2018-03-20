using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class OrderDetailEntity//:BaseEntity
    {
        public string OrderCode { get; set; }
        public int ProcudeID { get; set; }
        public string ProcudeName { get; set; }
        public decimal? Price { get; set; }
        public int? PV { get; set; }
        public int OrderSum { get; set; }
        public decimal? OrderTotal { get; set; }
        public int? PVTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
