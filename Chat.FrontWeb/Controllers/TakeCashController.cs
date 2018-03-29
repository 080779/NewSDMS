using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.TakeCash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class TakeCashController : FrontBaseController
    {
        public ITakeCashService takeCashService { get; set; }
        //public IHolderService holderService { get; set; }
        public ActionResult List()
        {
            TakeCashListViewModel model = new TakeCashListViewModel();
            model.TakeCashes= takeCashService.GetByHolderId(2);
            model.Holder = holderService.GetById(2);
            return View(model);
        }
        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(long id,decimal amount)
        {
            takeCashService.Apply(id, amount);
            return Json(new AjaxResult { Status = "1" });
        }
    }
}