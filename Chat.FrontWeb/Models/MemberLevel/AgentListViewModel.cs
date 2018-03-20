using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Models.MemberLevel
{
    public class AgentListViewModel
    {
        public AgentListDTO AgentList { get; set; }
        public MemberListDTO Member { get; set; }
        public AgentListDTO[] Agent { get; set; }
    }
}