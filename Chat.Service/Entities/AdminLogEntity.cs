using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    /// <summary>
    /// 后台日志实体类
    /// </summary>
    public class AdminLogEntity : BaseEntity
    {
        public long AdminUserId { get; set; }
        public virtual AdminEntity AdminUser { get; set; }
        public string IpAddress { get; set; }
        public string Message { get; set; }
    }
}
