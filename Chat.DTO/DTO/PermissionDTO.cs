using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class PermissionDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long? TypeId { get; set; }
        public string URL { get; set; }
        public string MenuName { get; set; }
        public long? ParentId { get; set; }
    }

    public class PermissionIdsDTO
    {
        public long Id { get; set; }
    }
}
