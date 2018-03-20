using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class ServiceQQEntity:BaseEntity
    {
        public string ServiceName { get; set; }
        public string QQnum { get; set; }
        public string QQ001 { get; set; }
        public string QQ002 { get; set; }
        public string QQ003 { get; set; }
    }
}
