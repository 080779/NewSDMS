using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.TakeCash
{
    public class TakeCashJournalModel
    {
        public JournalDTO[] Journals { get; set; }
        public string Page { get; set; }
    }
}