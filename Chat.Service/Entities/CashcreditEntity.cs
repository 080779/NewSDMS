using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class CashcreditEntity:BaseEntity
    {
        public int CreditID { get; set; }
        public int UserID { get; set; }
        public int BNumber { get; set; }
        public int BTradeNum { get; set; }
        public int BEndNum { get; set; }
        public int BValues { get; set; }
        public int SNumber { get; set; }
        public int STradeNum { get; set; }
        public int SEndNum { get; set; }
        public int SValues { get; set; }
    }
}
