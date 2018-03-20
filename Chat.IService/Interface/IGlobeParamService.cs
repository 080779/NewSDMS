using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IGlobeParamService:IServiceSupport
    {
        GlobeParamDTO[] GetAll();
        bool Update(long? id, string paramVarchar);
        GlobeParamDTO GetById(long? id);
        GlobeParamDTO GetByName(string name);
    }
}
