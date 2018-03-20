using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class GlobeParamDTO
    {
        public long ID { get; set; }
        public string ParamName { get; set; }
        public decimal? ParamAmount { get; set; }
        public int? ParamInt { get; set; }
        public string ParamVarchar { get; set; }
        public string Remark { get; set; }
        public string EndRemark { get; set; }
        public int? ParamType { get; set; }
        public int IsEdit { get; set; }
    }
}
