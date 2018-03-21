using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class PermissionEntity:BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long? TypeId { get; set; }
        public string URL { get; set; }
        public string MenuName { get; set; }
        public long? ParentId { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}
