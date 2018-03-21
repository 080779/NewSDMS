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
        public long AddNew(string userName, string pwd, long?[] roleIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                AdminEntity admin = new AdminEntity();
                admin.Name = userName;
                admin.PasswordHash = CommonHelper.GetMD5(pwd);
                //admin.ThirdPassword = CommonHelper.GetMD5(tpwd);
                var roles= cs.GetAll().Where(r => roleIds.Contains(r.Id));
                foreach(var role in roles)
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

        public bool Update(long Id,string userName, string pwd, long?[] roleIds)
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
                admin.Name = userName;
                if(!string.IsNullOrEmpty(pwd))
                {
                    admin.PasswordHash = CommonHelper.GetMD5(pwd);
                }
                //if (!string.IsNullOrEmpty(tpwd))
                //{
                //    admin.ThirdPassword = CommonHelper.GetMD5(tpwd);
                //}
                admin.Roles.Clear();
                var roles = cs.GetAll().Where(r => roleIds.Contains(r.Id));
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
                var admin = cs.GetAll().SingleOrDefault(a=>a.Id==Id);
                if(admin==null)
                {
                    return null;
                }
                return new AdminEditDTO { CreateTime = admin.CreateTime, Id = admin.Id, UserName = admin.Name, RoleIds = admin.Roles.Select(r => new RoleIdDTO { Id=r.Id}).ToArray() };
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
                return new AdminDTO { CreateTime = admin.CreateTime, Id = admin.Id, UserName = admin.Name, TrueName = admin.TrueName};
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
                if(admins==null)
                {
                    return result;
                }
                admins = admins.Where(a => a.Name != "admin");
                result.TotalCount = admins.LongCount();
                result.AdminList = admins.OrderByDescending(a => a.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(a => new AdminListDTO { Id = a.Id, CreateTime = a.CreateTime, UserName = a.Name }).ToArray();
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

        public long CheckLogin(string usercode, string password)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.Name == usercode);
                if (admin == null)
                {
                    return 0;//账户不存在
                }
                if (admin.PasswordHash != CommonHelper.GetMD5(password))
                {
                    return -1;//密码错误
                }
                return admin.Id;
            }
        }
    }
}
