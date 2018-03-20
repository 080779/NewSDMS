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
        /// 添加账户明细记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="InAmount"></param>
        /// <param name="OutAmount"></param>
        /// <param name="Balance"></param>
        /// <param name="JournalType"></param>
        /// <param name="Remark"></param>
        /// <param name="RemarkEn"></param>
        /// <returns></returns>
        long Add(long UserID, decimal InAmount, decimal OutAmount, decimal Balance, int JournalType, string Remark, string RemarkEn);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<JournalDTO> GetList();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="TrueName"></param>
        /// <param name="JournalType"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        JournalPageResult GetPageList(long UserID, string UserCode, string TrueName, int JournalType, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize);

        List<JournalDTO> GetPageListTest(long UserID, string UserCode, string TrueName, int JournalType, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize);
    }

    public class JournalPageResult
    {
        public long TotalCount { get; set; }
        public JournalDTO[] Journals { get; set; }
    }
}