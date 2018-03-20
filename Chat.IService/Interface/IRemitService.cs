using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IRemitService : IServiceSupport
    {
        /// <summary>
        /// 添加充值记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Amount"></param>
        /// <param name="BankName"></param>
        /// <param name="BankAccount"></param>
        /// <param name="BankAccountUser"></param>
        /// <returns></returns>
        long Add(RemitDTO dto);

        /// <summary>
        /// 更新充值记录状态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        int UpdateState(long ID, int State);

        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        List<RemitDTO> GetList();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        RemitPageResult GetPageList(long UserID, string UserCode, string TrueName, int State, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        RemitDTO GetModelByID(long ID);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int Del(long ID);
    }

    public class RemitPageResult
    {
        public long TotalCount { get; set; }
        public RemitDTO[] Remits { get; set; }
    }

}
