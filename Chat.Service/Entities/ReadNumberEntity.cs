using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{
    public class ReadNumberEntity:BaseEntity
    {
        public virtual HolderEntity Holder { get; set; }
        public long HolderId { get; set; }
        public virtual NewsEntity News { get; set; }
        public long NewsId { get; set; }
    }
}
