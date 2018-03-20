using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDMS.Service.Entities
{    
    public class ProduceTypeEntity//:BaseEntity
    {
        public int ParentID { get; set; }
        public string TypeName { get; set; }
        public int? Type01 { get; set; }
        public int? Type02 { get; set; }
        public decimal? Type03 { get; set; }
        public decimal? Type04 { get; set; }
        public string Type05 { get; set; }
        public string Type06 { get; set; }
    }
}
