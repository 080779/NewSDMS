using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class RoleService : IRoleService
    {
        public long AddNew(string name,string description,long?[] permissionIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(dbc);
                RoleEntity role = new RoleEntity();
                role.Name = name;
                role.Description = description;
                var permissions = cs.GetAll().Where(p => permissionIds.Contains(p.Id));
                foreach (var permission in permissions)
                {
                    role.Permissions.Add(permission);
                }
                dbc.Role.Add(role);
                dbc.SaveChanges();
                return role.Id;
            }
        }

        public bool Update(long Id, string name, string description, long?[] permissionIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> rcs = new CommonService<RoleEntity>(dbc);
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(dbc);
                RoleEntity role = rcs.GetAll().SingleOrDefault(r => r.Id == Id);
                if(role==null)
                {
                    return false;
                }
                role.Name = name;
                role.Description = description;
                role.Permissions.Clear();
                var permissions = cs.GetAll().Where(p => permissionIds.Contains(p.Id));
                foreach (var permission in permissions)
                {
                    role.Permissions.Add(permission);
                }
                dbc.SaveChanges();
                return true;
            }
        }

        public int Delete(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                var role=cs.GetAll().SingleOrDefault(r => r.Id == Id);
                if(role==null)
                {
                    return 1;//删除的数据不存在
                }
                if(role.AdminUsers.Where(a=>a.IsDeleted==false).Any())
                {
                    return 2;//删除的角色已经有管理员用户拥有
                }
                role.IsDeleted = true;
                dbc.SaveChanges();
                return 0;
            }
        }

        public RoleDTO[] GetAll()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                return cs.GetAll().OrderByDescending(r => r.CreateTime).ToList().Select(r => new RoleDTO {CreateTime=r.CreateTime,Description=r.Description,Id=r.Id,Name=r.Name }).ToArray();
            }
        }

        public RoleDTO GetById(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                var role = cs.GetAll().SingleOrDefault(r => r.Id == Id);
                if(role==null)
                {
                    return null;
                }
                return new RoleDTO { CreateTime = role.CreateTime, Description = role.Description, Id = role.Id, Name = role.Name };
            }
        }
    }
}
