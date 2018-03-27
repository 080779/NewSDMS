using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class JournalEntity:BaseEntity
    {
        public string Remark { get; set; }
        public decimal? InAmount { get; set; }
        public decimal? OutAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public virtual JournalTypeEntity JournalType { get; set; }
        public long JournalTypeId { get; set; }
        public virtual HolderEntity Holder { get; set; }
        public long HolderId { get; set; }
    }
}
