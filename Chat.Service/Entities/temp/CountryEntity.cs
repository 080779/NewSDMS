using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class CountryEntity//:BaseEntity
    {
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryName_en { get; set; }
        public string Code { get; set; }
    }
}
