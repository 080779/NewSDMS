using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Models.MyInfo
{
    public class InfoModel
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string BankAccount { get; set; }
        public string UrgencyName { get; set; }
        public string UrgencyContact { get; set; }
    }
}