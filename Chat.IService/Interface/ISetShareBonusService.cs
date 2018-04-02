using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface ISetShareBonusService:IServiceSupport
    {
        /// <summary>
        /// true为定向，false为平均
        /// </summary>
        /// <returns></returns>
        bool GetSetPattern();
        SetShareBonusDTO GetSet();
        bool Update(decimal rate);
        /// <summary>
        /// 设置分红模式
        /// </summary>
        /// <param name="flag">true为定向，false为平均</param>
        /// <returns></returns>
        bool Update(bool flag);
    }
}
