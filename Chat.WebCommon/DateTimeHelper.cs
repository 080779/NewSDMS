using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Common
{
    public static class DateTimeHelper
    {
        public static DateTime GetBeginDate(DateTime dateTime)
        {
            return DateTime.Parse(dateTime.ToString("yyyy-MM-dd"));
        }

        public static DateTime GetEndDate(DateTime dateTime)
        {
            return DateTime.Parse(dateTime.ToString("yyyy-MM-dd") + " 23:59:59");
        }
    }
}
