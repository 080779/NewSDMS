using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class SetShareBonusDTO:BaseDTO
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal OldRate { get; set; }
        public bool Flag { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
