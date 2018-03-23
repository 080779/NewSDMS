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
        bool Delete(long id);
        decimal ClacAmount(long id, long copies);
        HolderSearchResult GetPageList(string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex,int pageSize);
    } 

    public class HolderSearchResult
    {
        public long TotalCount { get; set; }
        public HolderDTO[] Holders { get; set; }
    }
}
