using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
   public class LeaveReMsgDTO : BaseDTO
    {
        public string ReContent { get; set; }
        public DateTime ReTime { get; set; }
        public string UserCode { get; set; }
        
    }
}
