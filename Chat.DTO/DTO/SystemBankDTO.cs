using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class SystemBankDTO : BaseDTO
    {
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountUser { get; set; }
        public int BankType { get; set; }
    }
}
