﻿using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.News
{
    public class NewsListViewModel
    {
        public NewsDTO[] News { get; set; }
        public string Page { get; set; }
    }
}