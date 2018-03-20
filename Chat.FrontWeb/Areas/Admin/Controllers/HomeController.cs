﻿using SDMS.DTO.DTO;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models;
using SDMS.Web.Areas.Admin.Models.User;
using SDMS.IService.Interface;
using SDMS.Service.Service;
using SDMS.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IUserService userService { get; set; }
        //adminService已经在AdminBaseController中定义
        public IPowerService powerService { get; set; }

        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            
            List<ParentModel> MenuList = new List<ParentModel>();
            foreach (var parent in powerService.GetByParentID(0))
            {
                ParentModel parentList = new ParentModel();
                parentList.Parent = parent;
                if(powerService.GetByTypeId((int)parent.TypeID)==null)
                {
                    continue;
                }
                parentList.Child = powerService.GetByTypeId((int)parent.TypeID);
                MenuList.Add(parentList);
            }
            model.MenuList = MenuList;
            model.ID = GetLoginID();
            return View(model);
        }

        public ActionResult ExportExcel()
        {
            AdminSearchResult result= adminService.GetPageList(1, 10);            
            return File(ExcelHelper.ExportExcel<AdminListDTO>(result.AdminList, "管理员"), "application/vnd.ms-excel", "测试.xls");
        }

        public ActionResult ZhuYe()
        {
            return View();
        }

        public ActionResult MemberLine()
        {
            return View();
        }

        public ActionResult GetMemberCountList()
        {
            List<UserAllCountModel> ulist = userService.GetMemberNumGroupbyTime();

            return Json(new AjaxResult { Status = "1", Data = ulist });
        }

    }
}