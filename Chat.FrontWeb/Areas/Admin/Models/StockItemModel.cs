using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models
{
    public class StockItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public long TotalCopies { get; set; }
        public long IssueCopies { get; set; }
    }
}