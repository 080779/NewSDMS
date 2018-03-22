using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IReadNumberService:IServiceSupport
    {
        long AddNew(long holderId, long newsId);
    }
}
