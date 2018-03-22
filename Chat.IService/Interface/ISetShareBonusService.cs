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
        SetShareBonusDTO GetById(long id);
        bool Update(long id, decimal rate);
    }
}
