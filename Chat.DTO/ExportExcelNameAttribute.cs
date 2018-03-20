using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDMS.DTO
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ExportExcelNameAttribute : Attribute
    {
        public string Name { get; set; }
        public ExportExcelNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}