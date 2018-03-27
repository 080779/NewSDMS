using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Models.Home
{
    public class ShareBonusViewModel
    {
        public HolderDTO Holder { get; set; }
        public decimal YesterdayBonus { get; set; }
        public JournalDTO[] Journals { get; set; }
    }
}