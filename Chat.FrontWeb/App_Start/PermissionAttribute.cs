using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.Web.App_Start
{
    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : Attribute
    {
        public string Permission { get; set; }
        public PermissionAttribute(string permission)
        {
            this.Permission = permission;
        }
    }
}