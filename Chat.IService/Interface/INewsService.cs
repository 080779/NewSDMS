using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface INewsService : IServiceSupport
    {
        long AddNew(long adminId,string title,string content,string imgUrl);
        bool Update(long id, string title, string content, string imgUrl);
        bool Delete(long id);
        NewsSearchResult GetPageList(string title,DateTime? startTime,DateTime? endTime,int pageIndex,int pageSize);
    }
    public class NewsSearchResult
    {
        public long TotalCount { get; set; }
        public NewsDTO[] News { get; set; }
    }
}
