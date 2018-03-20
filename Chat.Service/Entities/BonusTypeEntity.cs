using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class BonusTypeEntity:BaseEntity
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string TypeNameEn { get; set; }
    }
}
