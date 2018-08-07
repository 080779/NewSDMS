using SDMS.DTO.DTO;
using SDMS.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IHolderService:IServiceSupport
    {
        long AddNew(HolderSvcModel model);
        bool Update(HolderSvcModel model);
        bool Update(long id, DateTime time);
        bool Update(long id, string address, string contact, string bankAccount, string urgencyName, string urgencyContact);
        bool Update(long id, string name, string mobile, bool gender, string idNumber, string contact);
        bool Delete(long id);
        decimal ClacAmount(long id, long copies);
        HolderSearchResult GetPageList(string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex,int pageSize);
        HolderDTO GetById(long id);
        bool CheckOpenId(string openId);
        long GetHoderIdByOpenId(string openId);
        long Login(string mobile, string password, string openId, string headImgUrl);
        long SetTradePwd(long id, string oldTradePwd, string tradePwd);
        long UnBind(long id);
        HolderCalcNumberDTO CalcNumber();
        TakeCashCalcNumberDTO TakeCashCalcNumber();
        bool SetPoint(long id);
        bool GetPoint(long id);
    } 

    public class HolderSearchResult
    {
        public long TotalCount { get; set; }
        public HolderDTO[] Holders { get; set; }
    }
}
