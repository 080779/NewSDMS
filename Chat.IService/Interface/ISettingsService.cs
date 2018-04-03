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
        SettingsDTO[] GetAll();
        SettingsDTO GetById(long id);
        long AddNew(string key, string value, string description);
        bool Update(long id, string value);
        string GetValueByKey(string key);
        SettingsDTO[] GetByName(string name);
    }
}
