using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface IBonusService : IServiceSupport
    {
        /// <summary>
        /// 添加奖金记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="TypeID"></param>
        /// <param name="Amount"></param>
        /// <param name="Sf"></param>
        /// <param name="Revenue"></param>
        /// <param name="IsSettled"></param>
        /// <param name="Remark"></param>
        /// <param name="RemarkEn"></param>
        /// <returns></returns>
        long Add(long UserID, int TypeID, decimal Amount, decimal Sf, decimal Revenue, int IsSettled, string Remark, string RemarkEn);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<BonusDTO> GetList();

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="TrueName"></param>
        /// <param name="TypeID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        BonusPageResult GetPageList(long UserID, string UserCode, string TrueName, int TypeID, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize);
    }

    public class BonusPageResult
    {
        public long TotalCount { get; set; }
        public BonusDTO[] BonusS { get; set; }
    }

}
