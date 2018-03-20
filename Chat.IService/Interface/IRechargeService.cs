using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface IRechargeService : IServiceSupport
    {
        /// <summary>
        /// 添加后台充值记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Amount"></param>
        /// <param name="YuAmount"></param>
        /// <param name="RechargeType"></param>
        /// <param name="RechargeStyle"></param>
        /// <returns></returns>
        long Add(long UserID, decimal Amount, decimal YuAmount, int RechargeType, int RechargeStyle);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<RechargeDTO> GetList();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="TrueName"></param>
        /// <param name="RechargeType">币种</param>
        /// <param name="RechargeStyle">充值类型</param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        RechargePageResult GetPageList(long UserID, string UserCode, string TrueName, int RechargeType, int RechargeStyle, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize);
    }

    public class RechargePageResult
    {
        public long TotalCount { get; set; }
        public RechargeDTO[] Recharges { get; set; }
    }

}