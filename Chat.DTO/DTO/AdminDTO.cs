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
        public string UserName { get; set; }
        public string TrueName { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }
        public string ThirdPassword { get; set; }
        public string FourPassword { get; set; }
    }

    public class AdminEditDTO:BaseDTO
    {
        public string UserName { get; set; }
        public RoleIdDTO[] RoleIds { get; set; }
    }

    public class AdminListDTO
    {
        //[ExportExcelName("编号")]对应生成excel表的列名，必须要有这个attribute
        [ExportExcelName("编号")]
        public long ID { get; set; }
        [ExportExcelName("姓名")]
        public string UserName { get; set; }
        [ExportExcelName("创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
