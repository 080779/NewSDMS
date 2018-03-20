using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class BonusTypeDTO : BaseDTO
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string TypeNameEn { get; set; }
    }
}
