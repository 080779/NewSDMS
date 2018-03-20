using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface IChangeService : IServiceSupport
    {
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ToUserID"></param>
        /// <param name="Amount"></param>
        /// <param name="ChangeType"></param>
        /// <param name="remark"></param>
        /// <param name="remarken"></param>
        /// <param name="toremark"></param>
        /// <param name="toremarken"></param>
        /// <returns></returns>
        long TransferMonbey(long UserID, long ToUserID, decimal Amount, long ChangeType, string remark, string remarken, string toremark, string toremarken);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        ChangeDTO[] GetList();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="ToUserCode"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        ChangePageResult GetPageList(long UserID, string UserCode, string ToUserCode, long ChangeType, DateTime? start, DateTime? end, int pageIndex, int pageSize);
    }

    public class ChangePageResult
    {
        public ChangeDTO[] ChangeList { get; set; }
        public long TotalCount { get; set; }
    }

}
