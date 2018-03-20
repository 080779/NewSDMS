using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface ITakeMoneyService : IServiceSupport
    {
        /// <summary>
        /// 添加提现记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Amount"></param>
        /// <param name="Cyjj"></param>
        /// <param name="Fee"></param>
        /// <param name="Flag"></param>
        /// <param name="BankName"></param>
        /// <param name="BankAccount"></param>
        /// <param name="BankAccountUser"></param>
        /// <returns></returns>
        long Add(long UserID, decimal Amount, decimal Cyjj, decimal Fee, int Flag, string BankName, string BankAccount, string BankAccountUser);

        /// <summary>
        /// 更新提现状态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        int UpdateFlag(long ID, int Flag);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<TakeMoneyDTO> GetList();
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="TrueName"></param>
        /// <param name="Flag"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        TakeMoneyPageResult GetPageList(long UserID, string UserCode, string TrueName, int Flag, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        TakeMoneyDTO GetModelByID(long ID);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int Del(long ID);
    }

    public class TakeMoneyPageResult
    {
        public long TotalCount { get; set; }
        public TakeMoneyDTO[] TakeMoneys { get; set; }
    }

}