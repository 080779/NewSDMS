using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Models.TakeCash
{
    public class TakeCashListViewModel
    {
        public HolderDTO Holder { get; set; }
        public TakeCashDTO[] TakeCashes { get; set; }
    }
}