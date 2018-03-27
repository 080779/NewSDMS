using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Models.MyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class MyInfoController : Controller
    {
        public IHolderService holderService { get; set; }
        public ActionResult List()
        {
            var dto=holderService.GetById(2);
            return View(dto);
        }
        [HttpGet]
        public ActionResult Info(long id)
        {
            var dto = holderService.GetById(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Info(InfoModel model)
        {
            holderService.Update(model.Id, model.Address, model.Contact, model.BankAccount, model.UrgencyName, model.UrgencyContact);
            return Json(new AjaxResult { Status="1"});
        }
    }
}