using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface IBankNameService : IServiceSupport
    {
        /// <summary>
        /// 添加银行信息
        /// </summary>
        /// <param name="bankName"></param>
        /// <param name="bankNameEn"></param>
        /// <returns></returns>
        long AddBankName(string bankName, string bankNameEn);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<BankNameDTO> GetList();

        /// <summary>
        /// 删除 0：删除成功，1：删除失败，2：已删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int Delete(long ID);
        List<BankNameDTO> GetAllList();
    }
}
