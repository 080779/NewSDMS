using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class NewsDTO : BaseDTO
    {     
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public int NewsType { get; set; }
        public string Publisher { get; set; }
        public string ImageURL { get; set; }
        public DateTime PublishTime { get; set; }
        public int NewType { get; set; }
        public string Classify { get; set; }
        public string Tags { get; set; }
        public int Click { get; set; }
        public int New01 { get; set; }
        public int New02 { get; set; }
        public decimal New03 { get; set; }
        public decimal New04 { get; set; }
        public string New05 { get; set; }
        public string New06 { get; set; }
        //public bool IsDeleted { get; set; }       
    }
}
