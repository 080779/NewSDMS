using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IReadNumberService:IServiceSupport
    {
        void AddNew(long holderId, long newsId);
        ReadNumberDTO[] GetByNewsId(long id);
    }
}
