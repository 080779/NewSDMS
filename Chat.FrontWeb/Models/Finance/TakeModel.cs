using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Models.Finance
{
    public class TakeModel
    {
        public decimal chanyerate { get; set; }
        public decimal feerate { get; set; }
        public decimal minmoney { get; set; }
        public decimal mybonus { get; set; }
        public decimal taketimes { get; set; }
    }
}