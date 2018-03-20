using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Areas.Admin.Models.Finance
{
    public class ChangeListModel
    {
        public ChangeDTO[] changeList { get; set; }
        public string Page { get; set; }
        public List<ChangeTypeDTO> changeTypeList { get; set; }
    }
}