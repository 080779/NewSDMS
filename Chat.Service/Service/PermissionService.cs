using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class PermissionService: IPermissionService
    {
        public PermissionDTO[] GetByParentId(long id)
        {
            using(MyDbContext dbc=new MyDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(dbc);
                return cs.GetAll().Where(p => p.ParentID == id).ToList().Select(p => new PermissionDTO { Description = p.Description, ID = p.ID, MenuName = p.MenuName, Name = p.Name, ParentID = p.ParentID, TypeID = p.TypeID, URL = p.URL }).ToArray();
            }           
        }

        public List<long> GetByRoleId(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                var role = cs.GetAll().SingleOrDefault(r => r.ID == id);
                if(role==null)
                {
                    role = new RoleEntity();
                }
                PermissionIdsDTO[] roleIds = role.Permissions.Where(p => p.IsDeleted == false).ToList().Select(p => new PermissionIdsDTO { ID = p.ID }).ToArray();
                List<long> lists = new List<long>();
                foreach(var roleid in roleIds)
                {
                    lists.Add(roleid.ID);
                }
                return lists;
            }
        }

        public List<long> GetByAdminId(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.ID == id);
                if (admin == null)
                {
                    admin = new AdminEntity();
                }
                PermissionIdsDTO[] permissionIds= admin.Roles.Where(p => p.IsDeleted == false).SelectMany(r => r.Permissions).Where(p => p.IsDeleted == false).Distinct().Select(p => new PermissionIdsDTO { ID = p.ID }).ToArray();
                List<long> lists = new List<long>();
                foreach(var permissionId in permissionIds)
                {
                    lists.Add(permissionId.ID);
                }
                return lists;
            }
        }

        public string GetByName(string name)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(dbc);
                var permission = cs.GetAll().SingleOrDefault(a => a.Name == name);
                if (permission == null)
                {
                    return null;
                }
                return permission.Description;
            }
        }
    }
}
