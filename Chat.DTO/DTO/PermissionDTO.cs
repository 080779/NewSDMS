using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class PermissionDTO
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long? TypeID { get; set; }
        public string URL { get; set; }
        public string MenuName { get; set; }
        public long? ParentID { get; set; }
    }

    public class PermissionIdsDTO
    {
        public long ID { get; set; }
    }
}
