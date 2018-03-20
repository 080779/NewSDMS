using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IRoleService:IServiceSupport
    {
        long AddNew(string name, string description, long?[] permissionIds);
        bool Update(long id, string name, string description, long?[] permissionIds);
        int Delete(long id);
        RoleDTO[] GetAll();
        RoleDTO GetById(long id);
    }
}
