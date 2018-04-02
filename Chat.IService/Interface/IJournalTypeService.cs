using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IJournalTypeService:IServiceSupport
    {
        JournalTypeDTO[] GetAll();
        long AddNew(string name,string description);
        bool Update(long id,string name,string description);
        bool Delete(long id);
        JournalTypeDTO[] GetByDecription(string decription);
    }
}
