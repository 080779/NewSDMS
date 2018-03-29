using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface ISettingsService:IServiceSupport
    {
        long AddNew(string key, string value, string description);
        bool Update(long id, string value, string description);
        string GetValueByKey(string key);
    }
}
