using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Models.TakeCash
{
    public class TakeCashApplyViewModel
    {
        public decimal MinTakeCash { get; set; }
        public HolderDTO Holder { get; set; }
    }
}