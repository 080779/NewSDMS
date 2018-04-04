using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class AdminLogService : IAdminLogService
    {
        public long AddNew(long adminUserId, string ipAddress, string message)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                AdminLogEntity adminLog = new AdminLogEntity();
                adminLog.AdminUserId = adminUserId;
                adminLog.IpAddress = ipAddress;
                adminLog.Message = message;
                dbc.AdminLogs.Add(adminLog);
                dbc.SaveChanges();
                return adminLog.Id;
            }
        }

        public AdminLogSearchResult GetPageList(string message ,DateTime? startTime, DateTime? endTime, string keyWord, int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdminLogEntity> cs = new CommonService<AdminLogEntity>(dbc);
                AdminLogSearchResult result = new AdminLogSearchResult();
                var logs = cs.GetAll();
                if(!string.IsNullOrEmpty(message))
                {
                    logs = logs.Where(l => l.Message.Contains(message));
                }
                if (startTime != null)
                {
                    logs = logs.Where(l => l.CreateTime > startTime);
                }
                if (endTime != null)
                {
                    logs = logs.Where(l => l.CreateTime < endTime);
                }
                if (!string.IsNullOrEmpty(keyWord))
                {
                    logs = logs.Where(l => l.Message.Contains(keyWord));
                }
                result.TotalCount = logs.LongCount();
                result.AdminLogs = logs.Include(l => l.AdminUser).OrderByDescending(l => l.CreateTime).Skip((pageIndex-1)*pageSize).Take(pageSize).ToList().
                    Select(l => new AdminLogDTO { AdminUserId = l.AdminUserId, AdminUserName = l.AdminUser.Name, AdminUserMobile = l.AdminUser.Mobile, CreateTime = l.CreateTime, Id = l.Id, IpAddress = l.IpAddress, Message = l.Message }).ToArray();
                return result;
            }
        }
    }
}
