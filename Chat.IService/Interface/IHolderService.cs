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
        bool Update(long id, string address, string contact, string bankAccount, string urgencyName, string urgencyContact);
        bool Delete(long id);
        decimal ClacAmount(long id, long copies);
        HolderSearchResult GetPageList(string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex,int pageSize);
        HolderDTO GetById(long id);
    } 

    public class HolderSearchResult
    {
        public long TotalCount { get; set; }
        public HolderDTO[] Holders { get; set; }
    }
}
