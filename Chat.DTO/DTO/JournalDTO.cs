using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class JournalDTO : BaseDTO
    {
        public string Remark { get; set; }
        public decimal? InAmount { get; set; }
        public decimal? OutAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public long JournalTypeId { get; set; }
        public string JournalTypeName { get; set; }
        //public long BonusTypeId { get; set; }
        public long HolderId { get; set; }
        public string HolderName { get; set; }
    }
}
