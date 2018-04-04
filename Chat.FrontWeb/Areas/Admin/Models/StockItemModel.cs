using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models
{
    public class StockItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TotalAmount { get; set; }
        public string TotalCopies { get; set; }
        public string IssueCopies { get; set; }
    }
}