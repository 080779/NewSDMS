using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class PowerEntity:BaseEntity
    {
        public int? TypeID { get; set; }
        public string URL { get; set; }
        public string MenuName { get; set; }
        public int? ParentID { get; set; }
    }
}
