using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class AgentDTO : BaseDTO
    {
        public string AgentCode { get; set; }
        public int Flag { get; set; }
        public long UserID { get; set; }
        public int AgentType { get; set; }
        public DateTime AppliTime { get; set; }
        public decimal JoinMoney { get; set; }
        public DateTime OpenTime { get; set; }
        public string PicLink { get; set; }
        public string AgentInProvince { get; set; }
        public string AgentInCity { get; set; }
        public string AgentAddress { get; set; }
        public int Agent001 { get; set; }
        public int Agent002 { get; set; }
        public string Agent003 { get; set; }
        public string Agent004 { get; set; }
        public string Agent005 { get; set; }
        public string Agent006 { get; set; }
    }
    public class AgentListDTO : BaseDTO
    {
        public string AgentCode { get; set; }
        public int Flag { get; set; }
        public long UserID { get; set; }
        public int AgentType { get; set; } 
        public DateTime? OpenTime { get; set; }
     
    }
}
  