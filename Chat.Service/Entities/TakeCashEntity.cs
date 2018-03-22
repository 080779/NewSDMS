using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class TakeCashEntity:BaseEntity
    {
        public decimal Amount { get; set; }
        public string Message { get; set; }
        public string ImgUrl { get; set; }
        public bool Flag { get; set; }
    }
}
