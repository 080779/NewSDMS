
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public partial class UserDTO: BaseDTO
    {
        public string UserCode { get; set; }
        public int LevelID { get; set; }
        public int RecommendID { get; set; }
        public string RecommendCode { get; set; }
        public string RecommendPath { get; set; }
        public int RecommendGenera { get; set; }
        public int ParentID { get; set; }
        public string ParentCode { get; set; }
        public string UserPath { get; set; }
        public int Layer { get; set; }
        public int Location { get; set; }
        public int IsOpend { get; set; }
        public int IsLock { get; set; }
        public int IsAgent { get; set; }
        public int AgentsID { get; set; }
        public decimal Emoney { get; set; }
        public decimal BonusAccount { get; set; }
        public decimal AllBonusAccount { get; set; }
        public decimal StockAccount { get; set; }
        public decimal StockMoney { get; set; }
        public int User003 { get; set; }
        public decimal ShopAccount { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime? OpenTime { get; set; }
        public decimal RegMoney { get; set; }
        public int BillCount { get; set; }
        public decimal GLmoney { get; set; }
        public DateTime? AddGLTime { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }
        public string ThreePassword { get; set; }
        public string SafetyCodeQuestion { get; set; }
        public string SafetyCodeAnswer { get; set; }
        public decimal LeftScore { get; set; }
        public decimal CenterScore { get; set; }
        public decimal RightScore { get; set; }
        public decimal LeftBalance { get; set; }
        public decimal CenterBalance { get; set; }
        public decimal RightBalance { get; set; }
        public decimal LeftNewScore { get; set; }
        public decimal CenterNewScore { get; set; }
        public decimal RightNewScore { get; set; }
        public decimal LeftZT { get; set; }
        public decimal CenterZT { get; set; }
        public decimal RightZT { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountUser { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankInProvince { get; set; }
        public string BankInCity { get; set; }
        public string Address { get; set; }
        public string TrueName { get; set; }
        public string NiceName { get; set; }
        public string IdenCode { get; set; }
        public string PhoneNum { get; set; }
        public int Gender { get; set; }
        public string QQnumer { get; set; }
        public int User001 { get; set; }
        public int User002 { get; set; }
        public int User004 { get; set; }
        public string User005 { get; set; }
        public string User006 { get; set; }
        public string User007 { get; set; }
        public string User008 { get; set; }
        public string User009 { get; set; }
        public string User010 { get; set; }
        public decimal User011 { get; set; }
        public decimal User012 { get; set; }
        public decimal User013 { get; set; }
        public decimal User014 { get; set; }
        public decimal User015 { get; set; }
        public decimal User016 { get; set; }
        public decimal User017 { get; set; }
        public decimal User018 { get; set; }
        public string LevelName { get; set; }
        public string Page { set; get; }
    }

    public class UserAllCountModel
    {
        public string regtime { get; set; }
        public int Pnum { get; set; }
    }

}
