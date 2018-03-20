using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class SystemMoneyEntity//:BaseEntity
    {
        public decimal MoneyAccount { get; set; }
        public decimal AllBonusAccount { get; set; }
        public decimal Money001 { get; set; }
        public decimal Money002 { get; set; }
    }
}
