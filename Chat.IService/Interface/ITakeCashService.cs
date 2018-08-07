using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface ITakeCashService:IServiceSupport
    {
        long Apply(long holderId,decimal Amount);
        bool Confirm(long id, string imgUrl);
        bool Reject(long id, string message);
        TakeCashSearchResult GetPageList(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex,int pageSize);
        TakeCashDTO[] GetByHolderId(long id);
        TakeCashDTO GetById(long id);
        int GetCountByHolderId(long id);
    }
    public class TakeCashSearchResult
    {
        public TakeCashDTO[] TakeCashs { get; set; }
        public long TotalCount { get; set; }
    }
}
