using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{   
    public class AddressEntity:BaseEntity
    {
        public int UserID { get; set; }
        public int TypeID { get; set; }
        public string AreaInProvince { get; set; }
        public string AreaInCity { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string MemberName { get; set; }
        public string PhoneNum { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Remark { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        public string Address03 { get; set; }
        public string Address04 { get; set; }
    }
}
