using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SDMS.Web.Models.Message
{
    public class NoticeMabageListModel
    {
        public NewsDTO news { get; set; }
        public NewsDTO[] newsList { get; set; }
        public string Page { get; set; }
    }
} 