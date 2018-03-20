using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class RoleDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleIdDTO
    {
        public long ID { get; set; }
    }
}
