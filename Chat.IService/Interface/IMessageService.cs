using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IMessageService:IServiceSupport
    {
        long AddNew(long holderId, long newsId, string contents);
        MessageSearchResult GetPageList(long? holderId, string name,string mobile, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize);
    }
    public class MessageSearchResult
    {
        public MessageDTO[] Messages { get; set; }
        public long TotalCount { get; set; }
    }
}
