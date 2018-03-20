using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class LinkEntity//:BaseEntity
    {
        public string LinkImage { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public int? Status { get; set; }
        public string Link001 { get; set; }
        public string Link002 { get; set; }
    }
}
