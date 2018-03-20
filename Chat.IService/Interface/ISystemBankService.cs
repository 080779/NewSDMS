using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface ISystemBankService : IServiceSupport
    {
        /// <summary>
        /// 添加系统银行账号信息
        /// </summary>
        /// <param name="bankName"></param>
        /// <param name="bankAccount"></param>
        /// <param name="bankAccountUser"></param>
        /// <param name="addr"></param>
        /// <param name="bankType"></param>
        /// <returns></returns>
        long AddSystemBank(string bankName, string bankAccount, string bankAccountUser, string addr, int bankType = 0);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        SystemBankDTO[] GetList();

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        SystemBankDTO GetDTOByID(long ID);

        /// <summary>
        /// 删除 0：删除成功，1：删除失败，2：已删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int Delete(long ID);
    }
}
