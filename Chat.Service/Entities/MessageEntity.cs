using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDMS.Service.Entities
{    
    public class MessageEntity:BaseEntity
    {
        public long HolderId { get; set; }
        public virtual HolderEntity Holder { get; set; }
        public long NewsId { get; set; }
        public virtual NewsEntity News { get; set; }
        public string Content { get; set; }
        public bool Flag { get; set; }
    }
}
