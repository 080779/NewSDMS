using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class AreaEntity : BaseEntity
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string Father { get; set; }
    }
}
