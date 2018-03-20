using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class RoleEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdminEntity> AdminUsers { get; set; } = new List<AdminEntity>();
        public virtual ICollection<PermissionEntity> Permissions { get; set; } = new List<PermissionEntity>();
    }
}
