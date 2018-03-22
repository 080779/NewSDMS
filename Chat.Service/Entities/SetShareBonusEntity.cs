using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class SetShareBonusEntity:BaseEntity
    {
        public decimal Rate { get; set; }
        public decimal OldRate { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
