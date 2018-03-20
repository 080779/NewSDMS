using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
    public interface ICurrencyNameService : IServiceSupport
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<CurrencyNameDTO> GetList();
    }
}
