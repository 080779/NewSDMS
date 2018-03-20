using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Models.MemberLevel
{
    public class MemberLevelListViewModel
    {
       public Member_LevelDTO[] Member_LevelDTO { get; set; }
       public LevelDTO[] BlogCategory { get; set; }
       public MemberListDTO MemberListDTO { get; set; }
       public shengji shengji { get; set; }
       public UserProDTO[] UserPro { get; set; }
    }
}