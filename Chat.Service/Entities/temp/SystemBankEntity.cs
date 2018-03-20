using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class SystemBankEntity//:BaseEntity
    {
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountUser { get; set; }
        public int BankType { get; set; }
    }
}
