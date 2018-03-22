using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IAdminLogService:IServiceSupport
    {
        long AddNew(long adminUserId, string ipAddress, string message);
        AdminLogSearchResult GetPageList(DateTime? startTime, DateTime? endTime, string keyWord, int currentIndex, int pageSize);
    }
    public class AdminLogSearchResult
    {
        public AdminLogDTO[] AdminLogs { get; set; }
        public long TotalCount { get; set; }
    }
}
