using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.Holder
{
    public class HolderAddModel
    {
        [Required(ErrorMessage ="姓名不能为空")]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public bool Gender { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 本金
        /// </summary>
        public decimal Amount { get; set; }
        public string Password { get; set; }
        public long Copies { get; set; }
    }
}