using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDMS.Service.Entities
{    
    public  class AdminEntity:BaseEntity
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Mobile { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}
