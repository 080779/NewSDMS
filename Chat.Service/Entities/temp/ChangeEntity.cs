using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class ChangeEntity//:BaseEntity
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
        //public virtual UserEntity UserInfo { get; set; }
        //public virtual UserEntity ToUserInfo { get; set; }
        public virtual ChangeTypeEntity ChangeTypeInfo { get; set; }
    }
}
