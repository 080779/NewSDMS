using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class CityDTO:BaseDTO
    {
        public string CityID { get; set; }
        public string City { get; set; }
        public string CityEn { get; set; }
        public string Father { get; set; }
    }
}
