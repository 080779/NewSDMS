using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class PowerDTO:BaseDTO
    {
        public int? TypeId { get; set; }
        public string URL { get; set; }
        public string MenuName { get; set; }
        public int? ParentId { get; set; }
    }
}
