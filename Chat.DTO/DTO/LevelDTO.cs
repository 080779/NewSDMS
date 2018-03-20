using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
   public class LevelDTO 
    {
        public int LevelID { get; set; } 
        public string LevelName { get; set; }

        //public decimal RegMoney { get; set; }
        //public int level01 { get; set; }
        //public int level02 { get; set; }
        //public string level03 { get; set; }
        //public string level04 { get; set; }
        //public decimal level05 { get; set; }
        //public decimal level06 { get; set; }
        //public decimal level07 { get; set; }
        //public decimal level08 { get; set; }
    }
    /// <summary>
    /// 升级前后金额
    /// </summary>
    public class shengji
    {
        public decimal shengji_Left { get; set; }
        public decimal shengji_right { get; set; }
        public decimal balance { get; set; }

    }
}
