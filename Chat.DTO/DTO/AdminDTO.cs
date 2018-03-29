using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class AdminDTO:BaseDTO
    {
        public string Name { get; set; }
        public string TrueName { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
    }

    public class AdminEditDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public RoleIdDTO[] RoleIds { get; set; }
    }

    public class AdminListDTO
    {
        //[ExportExcelName("编号")]对应生成excel表的列名，必须要有这个attribute
        [ExportExcelName("编号")]
        public long Id { get; set; }
        [ExportExcelName("姓名")]
        public string Name { get; set; }
        [ExportExcelName("创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
