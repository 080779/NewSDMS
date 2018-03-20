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
        public string UserName { get; set; }
        public string TrueName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }
        //public string ThirdPassword { get; set; }
        //public string FourPassword { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}
