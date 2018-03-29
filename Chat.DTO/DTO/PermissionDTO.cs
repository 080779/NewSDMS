using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class PermissionDTO:BaseDTO
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public class PermissionIdsDTO
    {
        public long Id { get; set; }
    }
}
