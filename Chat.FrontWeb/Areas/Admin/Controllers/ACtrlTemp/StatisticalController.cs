using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACtrlTemp.SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 统计控制器
    /// </summary>
    public class StatisticalController : Controller
    {
        public IUserService userService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Load()
        {
            var datas= userService.IncreaseCount();
            List<string> strs = new List<string>();
            List<long> nums = new List<long>();
            foreach(var d in datas)
            {
                strs.Add(d.RegTime);
                nums.Add(d.Count);
            }

            var ser = new { Name = "直接访问", Type = "bar", BarWidth = "60%", Data = nums };
            
            var data = new { ser, strs };

            return Json(new AjaxResult { Status="1",Data= data});
        }
    }
}