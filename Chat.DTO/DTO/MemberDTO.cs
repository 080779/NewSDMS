using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class MemberDTO: BaseDTO
    {
        //public long ID { get; set; }
        public string UserCode { get; set; }
        public int LevelID { get; set; }
        public long RecommendID { get; set; }
        public long ParentID { get; set; }
        public int IsOpend { get; set; }
        public string TrueName { get; set; }
        public string PhoneNum { get; set; }
        public int IsLock { get; set; }
        //public DateTime CreateTime { get; set; } 
    }

    public class MemberListDTO : BaseDTO
    {
        public string UserCode { get; set; }
        public int LevelID { get; set; }
        public long RecommendID { get; set; }
        public long ParentID { get; set; }
        public int IsOpend { get; set; }
        public decimal Emoney { get; set; }
        public string TrueName { get; set; }
        public string PhoneNum { get; set; }
        public int IsLock { get; set; }
        public string RecommendCode { get; set; }
        public DateTime? OpenTime { get; set; }
        public string LevelName { get; set; }

        public string BankAccount { get; set; }//銀行賬號
        public string BankAccountUser { get; set; }//開户姓名
        public string BankName { get; set; }//開户銀行
        public string BankBranch { get; set; }//支行名稱
        public string BankInProvince { get; set; }//銀行所在省份 
        public int Location { get; set; }//左区， 右区 
        public decimal RegMoney { get; set; }//注册金额
        public string ParentCode { get; set; }
        public string IdenCode { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }
        public string ThreePassword { get; set; } 
            
    }
    /// <summary>
    /// 获取等级 
    /// </summary>
    public class BlogCategoryDTO
    {
        public int LevelID { get; set; }
        public string LevelName { get; set; }
    }
}
