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
        public long AddNew(string userName, string pwd, string spwd, string tpwd, long?[] roleIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                AdminEntity admin = new AdminEntity();
                admin.UserName = userName;
                admin.Password = CommonHelper.GetMD5(pwd);
                admin.SecondPassword = CommonHelper.GetMD5(spwd);
                //admin.ThirdPassword = CommonHelper.GetMD5(tpwd);
                var roles= cs.GetAll().Where(r => roleIds.Contains(r.ID));
                foreach(var role in roles)
                {
                    admin.Roles.Add(role);
                } 
                dbc.Admin.Add(admin);
                dbc.SaveChanges();
                return admin.ID;
            }
        }

        public bool CheckUserName(string userName)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> acs = new CommonService<AdminEntity>(dbc);
                return acs.GetAll().Any(a => a.UserName == userName);
            }
        }

        public bool Update(long id,string userName, string pwd, string spwd, string tpwd, long?[] roleIds)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(dbc);
                CommonService<AdminEntity> acs = new CommonService<AdminEntity>(dbc);
                AdminEntity admin = acs.GetAll().SingleOrDefault(a=>a.ID==id);
                if(admin==null)
                {
                    return false;
                }
                admin.UserName = userName;
                if(!string.IsNullOrEmpty(pwd))
                {
                    admin.Password = CommonHelper.GetMD5(pwd);
                }
                if (!string.IsNullOrEmpty(spwd))
                {
                    admin.SecondPassword = CommonHelper.GetMD5(spwd);
                }
                //if (!string.IsNullOrEmpty(tpwd))
                //{
                //    admin.ThirdPassword = CommonHelper.GetMD5(tpwd);
                //}
                admin.Roles.Clear();
                var roles = cs.GetAll().Where(r => roleIds.Contains(r.ID));
                foreach (var role in roles)
                {
                    admin.Roles.Add(role);
                }
                dbc.SaveChanges();
                return true;
            }
        }

        public AdminEditDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a=>a.ID==id);
                if(admin==null)
                {
                    return null;
                }
                return new AdminEditDTO { CreateTime = admin.CreateTime, ID = admin.ID, UserName = admin.UserName, RoleIds = admin.Roles.Select(r => new RoleIdDTO { ID=r.ID}).ToArray() };
            }
        }

        public AdminDTO GetByAdminId(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.ID == id);
                if (admin == null)
                {
                    return null;
                }
                return new AdminDTO { CreateTime = admin.CreateTime, ID = admin.ID, UserName = admin.UserName, TrueName = admin.TrueName, Password = admin.Password, SecondPassword = admin.SecondPassword };
            }
        }

        public long GetIdByName(string userName)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var admin = cs.GetAll().SingleOrDefault(a => a.UserName == userName);
                if (admin == null)
                {
                    return 0;
                }
                return admin.ID;
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
                admins = admins.Where(a => a.UserName != "admin");
                result.TotalCount = admins.LongCount();
                result.AdminList = admins.OrderByDescending(a => a.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(a => new AdminListDTO { ID = a.ID, CreateTime = a.CreateTime, UserName = a.UserName }).ToArray();
                return result;
            }
        }

        public bool Delete(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminEntity> cs = new CommonService<AdminEntity>(dbc);
                var user = cs.GetAll().SingleOrDefault(u => u.ID == id);
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
                var user = cs.GetAll().Include(u => u.Roles).AsNoTracking().SingleOrDefault(u => u.ID == adminUserId);
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
                var admin = cs.GetAll().SingleOrDefault(a => a.UserName == usercode);
                if (admin == null)
                {
                    return 0;//账户不存在
                }
                if (admin.Password != CommonHelper.GetMD5(password))
                {
                    return -1;//密码错误
                }
                return admin.ID;
            }
        }
    }
}
