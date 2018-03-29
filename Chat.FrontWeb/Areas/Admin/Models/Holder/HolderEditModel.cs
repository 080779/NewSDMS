using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.Areas.Admin.Models.Holder
{
    public class HolderEditModel
    {
        public long Id { get; set; }
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
        public string Contact { get; set; }
    }
}