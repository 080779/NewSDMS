using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.App_Start
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ActDescriptionAttribute : Attribute
    {
        public string ActDescription { get; set; }
        public ActDescriptionAttribute(string actDescription)
        {
            this.ActDescription = actDescription;
        }
    }
}