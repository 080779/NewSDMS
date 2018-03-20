using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    /// <summary>
    /// 实体类父类
    /// </summary>
    public class BaseEntity
    {
        public long ID { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
