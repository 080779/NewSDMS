using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IReadNumberService:IServiceSupport
    {
        void AddNew(long holderId, long newsId);
        ReadNumberDTO[] GetByNewsId(long id);
        ReadSearchResult GetPageList(long id, string name, DateTime? startTime, DateTime? endTime, int pageIndex ,int pageSize);
    }
    public class ReadSearchResult
    {
        public ReadNumberDTO[] ReadNumbers { get; set; }
        public long TotalCount { get; set; }
    }
}
