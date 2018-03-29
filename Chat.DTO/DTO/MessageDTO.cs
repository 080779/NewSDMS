using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class MessageDTO:BaseDTO
    {
        public long HolderId { get; set; }
        public string HolderName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Contents { get; set; }
        public long NewsId { get; set; }
        public string NewsTitle { get; set; }
        public bool Flag { get; set; }
    }
}
