using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.Message
{
    public class MessageListViewModel
    {
        public MessageDTO[] Messages { get; set; }
        public string Page { get; set; }
    }
}