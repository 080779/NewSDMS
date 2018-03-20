using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Common
{
    public class AjaxResult
    {
        public string Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
        public string PageIndex { get; set; }
    }
}
