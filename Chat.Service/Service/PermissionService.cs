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
    public class PermissionService : IPermissionService
    {
        public List<long> GetByRoleId(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                var role = cs.GetAll().SingleOrDefault(r => r.Id == Id);
                if (role == null)
                {
                    role = new RoleEntity();
                }
                PermissionIdsDTO[] roleIds = role.Permissions.Where(p => p.IsDeleted == false).ToList().Select(p => new PermissionIdsDTO { Id = p.Id }).ToArray();
                List<long> lists = new List<long>();
                foreach (var roleId in roleIds)
                {
                    lists.Add(roleId.Id);
                }
                return lists;
            }
        }

        public List<long> GetByAdminId(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Id == Id);
                if (admin == null)
                {
                    admin = new AdminEntity();
                }
                PermissionIdsDTO[] permissionIds = admin.Roles.Where(p => p.IsDeleted == false).SelectMany(r => r.Permissions).Where(p => p.IsDeleted == false).Distinct().Select(p => new PermissionIdsDTO { Id = p.Id }).ToArray();
                List<long> lists = new List<long>();
                foreach (var permissionId in permissionIds)
                {
                    lists.Add(permissionId.Id);
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
        public PermissionDTO[] GetAll()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(dbc);
                var permissions = cs.GetAll();
                if (permissions == null)
                {
                    return null;
                }
                return permissions.Select(p => new PermissionDTO { Id = p.Id, Description = p.Description, Name = p.Name,CreateTime=p.CreateTime }).ToArray();
            }
        }
    }
}
