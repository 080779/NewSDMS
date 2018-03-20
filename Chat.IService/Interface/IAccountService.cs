using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDMS.IService.Interface
{
    public interface IAccountService: IServiceSupport
    {
        // 获得总收入
        decimal GetIncomeTotal();
        /// 获得总支出
        decimal GetPayTotal();
    }
}
