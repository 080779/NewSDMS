using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class ChangeDTO : BaseDTO
    {
        public long UserID { get; set; }
        public int ToUserType { get; set; }
        public long ToUserID { get; set; }
        public long ChangeType { get; set; }
        public int? MoneyType { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int? Change001 { get; set; }
        public int? Change002 { get; set; }
        public string Change003 { get; set; }
        public string Change004 { get; set; }
        public decimal? Change005 { get; set; }
        public decimal? Change006 { get; set; }
        public string UserCode { get; set; }
        public string TrueName { get; set; }
        public string ToUserCode { get; set; }
        public string ToTrueName { get; set; }
        public string ChangeTypeName { get; set; }
        public string ChangeTypeNameEn { get; set; }
    }
}
