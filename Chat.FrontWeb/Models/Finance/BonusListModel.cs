using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDMS.DTO.DTO;

namespace SDMS.Web.Models.Finance
{
    public class BonusListModel
    {
        public BonusDTO[] bonusList { get; set; }
        public string Page { get; set; }
        public List<BonusTypeDTO> bonusTypeList { get; set; }
    }
}