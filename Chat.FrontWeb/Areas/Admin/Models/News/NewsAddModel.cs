using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.News
{
    public class NewsAddModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage ="公告标题不能为空")]
        [MaxLength(200,ErrorMessage ="标题字数必须小于100字")]
        public string Title { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "公告图片不能为空")]
        public string ImgURL { get; set; }
        public string Contents { get; set; }
    }
}