using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IPermissionService:IServiceSupport
    {
        List<long> GetByRoleId(long Id);
        List<long> GetByAdminId(long Id);
        string GetByName(string name);
        PermissionDTO[] GetAll();
    }
}
