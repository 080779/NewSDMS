using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IDataBaseService : IServiceSupport
    {
        /// <summary>
        /// 执行清空数据库数据存储过程
        /// </summary>
        /// <returns>返回受影响行数</returns>
        int DataBaseClear();
    }
}
