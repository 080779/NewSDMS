using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SDMS.DTO.DTO
{
    public class AccountDTO: BaseDTO
    {
        public DateTime recordTime { get; set; }
        public decimal sr { get; set; }
        public decimal zc { get; set; }
        public decimal yl { get; set; }
       
    }
}
