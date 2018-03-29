using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.News
{
    public class NewsEditModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "公告标题不能为空")]
        public string Title { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "公告图片不能为空")]
        public string ImgURL { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "公告内容不能为空")]
        public string Contents { get; set; }
    }
}