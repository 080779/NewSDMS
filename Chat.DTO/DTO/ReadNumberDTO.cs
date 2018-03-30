using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class ReadNumberDTO
    {
        [ExportExcelName("公告标题")]
        public string NewsTitle { get; set; }
        [ExportExcelName("股东名")]
        public string HolderName { get; set; }
        [ExportExcelName("阅读时间")]
        public string CreateTime { get; set; }
    }
}
