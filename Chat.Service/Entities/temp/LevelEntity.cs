using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class LevelEntity//:BaseEntity
    {
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        public decimal RegMoney { get; set; }
        public int? level01 { get; set; }
        public int? level02 { get; set; }
        public string level03 { get; set; }
        public string level04 { get; set; }
        public decimal? level05 { get; set; }
        public decimal? level06 { get; set; }
        public decimal? level07 { get; set; }
        public decimal? level08 { get; set; }
    }
}
