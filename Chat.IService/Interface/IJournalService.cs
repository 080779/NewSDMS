using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface IJournalService : IServiceSupport
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="holderId"></param>
        /// <param name="mobile"></param>
        /// <param name="name"></param>
        /// <param name="journalTypeId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        JournalPageResult GetPageList(long? holderId, string mobile, string name, long? journalTypeId, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize);
        JournalDTO[] GetBonusList(long id, string journalType, string journalType01, int pageSize);
        decimal YesterdayBonus(long id);
    }

    public class JournalPageResult
    {
        public long TotalCount { get; set; }
        public JournalDTO[] Journals { get; set; }
    }
}