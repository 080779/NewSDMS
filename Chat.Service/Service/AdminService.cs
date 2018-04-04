using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.Service.Entities;
using SDMS.Common;
using System.Data.Entity;

namespace SDMS.Service.Service
{
    public class AdminService : IAdminService
    {
        public long AddNew(string name, string mobile, string description, string password, long?[] roleIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                CommonService<AdminEntity> acs = new CommonService<AdminEntity>(dbc);
                var entity = acs.GetAll().SingleOrDefault(a => a.Name == name);
                if(entity!=null)
                {
                    return -2;
                }
                AdminEntity admin = new AdminEntity();
                admin.Name = name;
                admin.Mobile = mobile;
                admin.Description = description;
                admin.PasswordSalt = CommonHelper.GetCaptcha(4);
                admin.PasswordHash = CommonHelper.GetMD5(password + admin.PasswordSalt);
                var roles= cs.GetAll().Where(r => roleIds.Contains(r.Id));
                if (roles == null)
                {
                    return -1;
                }
                foreach (var role in roles)
                {
                    admin.Roles.Add(role);
                } 
                dbc.Admin.Add(admin);
                dbc.SaveChanges();
                return admin.Id;
            }
        }

        public bool CheckUserName(string userName)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> acs = new CommonService<AdminEntity>(dbc);
                return acs.GetAll().Any(a => a.Name == userName);
            }
        }

        public bool Update(long Id, string name, string mobile, string description, string password, long?[] roleIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                CommonService<AdminEntity> acs = new CommonService<AdminEntity>(dbc);
                AdminEntity admin = acs.GetAll().SingleOrDefault(a=>a.Id==Id);
                if(admin==null)
                {
                    return false;
                }
                admin.Name = name;
                admin.Mobile = mobile;
                admin.Description = description;
                if(!string.IsNullOrEmpty(password))
                {
                    admin.PasswordHash = CommonHelper.GetMD5(password+admin.PasswordSalt);
                }
                admin.Roles.Clear();
                var roles = cs.GetAll().Where(r => roleIds.Contains(r.Id));
                if(roles.LongCount()<=0)
                {
                    return false;
                }
                foreach (var role in roles)
                {
                    admin.Roles.Add(role);
                }
                dbc.SaveChanges();
                return true;
            }
        }

        public AdminEditDTO GetById(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Id == Id);
                if (admin == null)
                {
                    return null;
                }
                return new AdminEditDTO { Mobile = admin.Mobile, Description = admin.Description, CreateTime = admin.CreateTime, Id = admin.Id, Name = admin.Name, RoleIds = admin.Roles.Select(r => new RoleIdDTO { Id = r.Id }).ToArray() };
            }
        }

        public AdminDTO GetByAdminId(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Id == Id);
                if (admin == null)
                {
                    return null;
                }
                return new AdminDTO { CreateTime = admin.CreateTime, Id = admin.Id, Name = admin.Name, TrueName = admin.TrueName};
            }
        }

        public long GetIdByName(string userName)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Name == userName);
                if (admin == null)
                {
                    return 0;
                }
                return admin.Id;
            }
        }

        public AdminSearchResult GetPageList(int pageIndex,int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                AdminSearchResult result = new AdminSearchResult();
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admins=cs.GetAll();
                //admins = admins.Where(a => a.Name != "admin");
                result.TotalCount = admins.LongCount();
                result.AdminList = admins.OrderByDescending(a => a.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(a => ToDTO(a)).ToArray();
                return result;
            }
        }

        public bool Delete(long Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var user = cs.GetAll().SingleOrDefault(u => u.Id == Id);
                if(user==null)
                {
                    return false;
                }
                user.IsDeleted = true;
                dbc.SaveChanges();
                return true;
            }
        }

        public bool HasPermission(long adminUserId, string permissionName)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var user = cs.GetAll().Include(u => u.Roles).AsNoTracking().SingleOrDefault(u => u.Id == adminUserId);
                if (user == null)
                {
                    return false;
                }
                return user.Roles.SelectMany(r => r.Permissions).Any(p => p.Name == permissionName);
            }
        }

        public long CheckLogin(string name, string password)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Name == name);
                if (admin == null)
                {
                    return 0;//账户不存在
                }
                if (admin.PasswordHash != CommonHelper.GetMD5(password+admin.PasswordSalt))
                {
                    return -1;//密码错误
                }
                return admin.Id;
            }
        }

        public string GetNameById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Id == id);
                if (admin == null)
                {
                    return null;
                }
                return admin.Name;
            }
        }
        public AdminDTO ToDTO(AdminEntity entity)
        {
            AdminDTO dto = new AdminDTO();
            dto.CreateTime = entity.CreateTime;
            dto.Description = entity.Description;
            dto.Id = entity.Id;
            dto.Mobile = entity.Mobile;
            dto.Name = entity.Name;
            dto.TrueName = entity.TrueName;
            return dto;
        }
    }
}
