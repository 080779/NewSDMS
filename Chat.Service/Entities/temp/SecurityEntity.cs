using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class SecurityEntity//:BaseEntity
    {
        public int SecurityID { get; set; }
        public string Question { get; set; }
        public int AddUserID { get; set; }
        public DateTime AddDate { get; set; }
        public int EditUserID { get; set; }
        public DateTime? EditDate { get; set; }
        public int Status { get; set; }
    }
}
