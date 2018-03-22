using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IShareBonusService:IServiceSupport
    {
        /// <summary>
        /// 平均分红
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns></returns>
        bool Average(decimal Amount);
        /// <summary>
        /// 定向分红
        /// </summary>
        /// <returns></returns>
        bool Directional(long setId);
    }
}
