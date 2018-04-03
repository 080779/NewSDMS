using SDMS.DTO.DTO;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models;
using SDMS.Web.Areas.Admin.Models.System;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CodeCarvings.Piczard;

namespace SDMS.Web.Areas.Admin.Controllers
{
    
    public class SystemController : AdminBaseController
    {
        //public IAdminService adminService { get; set; }
        //public IPermissionService permissionService { get; set; }
        public IRoleService roleService { get; set; }
        public IAdminLogService adminLogService { get; set; }
        public ISettingsService settingsService { get; set; }
        public IDataBaseService dataBaseService { get; set; }

        #region 管理员管理
        [ActDescription("管理员管理列表")]
        [Permission("系统管理")]
        public ActionResult AdminManager()
        {            
            return View();
        }
        [Permission("系统管理")]
        public PartialViewResult AdminManagerGetPage(int pageIndex=1)
        {
            int pageSize = 3;
            AdminListViewModel model = new AdminListViewModel();
            AdminSearchResult result = adminService.GetPageList(pageIndex, pageSize);
            model.AdminList = result.AdminList;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = result.TotalCount;

            if (result.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return PartialView("AdminManagerPaging", model);
        }
        [Permission("系统管理")]
        public ActionResult AdminAdd()
        {
            RoleDTO[] dtos = roleService.GetAll();
            return View(dtos);
        }
        [Permission("系统管理")]
        [HttpPost]
        [ActDescription("添加管理员")]
        public ActionResult AdminAdd(AdminAddModel model)
        {
            if(string.IsNullOrEmpty(model.Name))
            {
                return Json(new AjaxResult { Status = "0",Msg="管理员名不能为空"});
            }
            
            if (model.RoleIds==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色必须选择" });
            }
            long id=adminService.AddNew(model.Name,model.Mobile,model.Description,model.Password,model.RoleIds);
            if(id<=0)
            {
                if(id==-2)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "管理员已经存在" });
                }
                return Json(new AjaxResult { Status = "0", Msg = "管理员用户添加失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/adminmanager" });
        }
        [Permission("系统管理")]
        public ActionResult AdminEdit(long id)
        {
            AdminEditViewModel model = new AdminEditViewModel();
            model.Roles= roleService.GetAll();
            model.Admin = adminService.GetById(id);
            List<long> lists = new List<long>();
            foreach(var role in model.Admin.RoleIds)
            {
                lists.Add(role.Id);
            }
            model.RoleIds = lists;
            return View(model);
        }
        [Permission("系统管理")]
        [HttpPost]
        [ActDescription("编辑管理员")]
        public ActionResult AdminEdit(AdminEditModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return Json(new AjaxResult { Status = "0", Msg = "用户名不能为空" });
            }
            if(model.RoleIds==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色必须选择" });
            }
            if (!adminService.Update(model.Id,model.Name,model.Mobile,model.Description,model.Password,model.RoleIds))
            {
                return Json(new AjaxResult { Status = "0", Msg = "管理员用户编辑失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/adminmanager" });
        }
        [Permission("系统管理")]
        [ActDescription("删除管理员")]
        public ActionResult AdminDel(long id)
        {
            if (!adminService.Delete(id))
            {
                return Json(new AjaxResult { Status = "0", Msg = "删除失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/adminmanager" });
        }
        #endregion

        #region 角色管理
        [Permission("系统管理")]
        [ActDescription("角色管理列表")]
        public ActionResult RoleManager()
        {
            return View();
        }
        [Permission("系统管理")]
        public PartialViewResult RoleManagerGetPage()
        {
            RoleDTO[]
            dtos = roleService.GetAll();
            return PartialView("RoleManagerPaging", dtos);
        }
        [Permission("系统管理")]
        public ActionResult RoleAdd()
        {
            var model= permissionService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Permission("系统管理")]
        [ActDescription("添加角色")]
        public ActionResult RoleAdd(string name,string description ,long?[] permIds)
        {
            if(string.IsNullOrEmpty(name))
            {
                return Json(new AjaxResult { Status = "0", Msg="角色名不能为空" });
            }
            if (string.IsNullOrEmpty(description))
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色描述不能为空" });
            }
            if(permIds == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择权限项" });
            }
            if (roleService.AddNew(name,description, permIds) <=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色添加失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/rolemanager" });
        }
        [Permission("系统管理")]
        public ActionResult RoleEdit(long id)
        {
            RoleEditViewModel model = new RoleEditViewModel();

            model.PermIds = permissionService.GetByRoleId(id);
            model.Role = roleService.GetById(id);
            model.Permissions = permissionService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Permission("系统管理")]
        [ActDescription("编辑角色")]
        public ActionResult RoleEdit(long? id,string name, string description, long?[] permIds)
        {
            if(id==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "参数错误" });
            }
            if (string.IsNullOrEmpty(name))
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色名不能为空" });
            }
            if (string.IsNullOrEmpty(description))
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色描述不能为空" });
            }
            if (permIds == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择权限项" });
            }
            if (!roleService.Update((long)id,name, description, permIds))
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色编辑失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/rolemanager" });
        }
        [Permission("系统管理")]
        [ActDescription("删除角色")]
        public ActionResult RoleDel(long? id)
        {
            if (id == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "参数错误" });
            }
            int num= roleService.Delete((long)id);
            if(num==1)
            {
                return Json(new AjaxResult { Status = "0", Msg = "要删除的数据不存在" });
            }
            if (num == 2)
            {
                return Json(new AjaxResult { Status = "0", Msg = "要删除的角色已经被管理员用户所拥有" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/rolemanager" });
        }
        #endregion
        #region 日志列表
        [Permission("系统管理")]
        [ActDescription("系统日志列表")]
        public ActionResult Log()
        {
            return View();
        }
        [Permission("系统管理")]
        public PartialViewResult LogList(DateTime? startTime,DateTime? endTime,int pageIndex=1)
        {
            int pageSize = 3;
            LogListViewModel model = new LogListViewModel();
            AdminLogSearchResult result = adminLogService.GetPageList(startTime, endTime,null, pageIndex, pageSize);
            model.AdminLogs = result.AdminLogs;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = result.TotalCount;

            if (result.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return PartialView("LogListPaging", model);
        }
        #endregion
        [HttpGet]
        [Permission("系统管理")]
        [ActDescription("系统参数设置列表")]
        public ActionResult SetList()
        {
            var model=settingsService.GetAll();
            return View(model);
        }
        [Permission("系统管理")]
        [HttpGet]
        public ActionResult Setting(long id)
        {
            var model = settingsService.GetById(id);
            return View(model);
        }
        [Permission("系统管理")]
        [ActDescription("系统参数设置")]
        [HttpPost]
        public ActionResult Setting(long id,string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return Json(new AjaxResult { Status = "0", Msg = "参数值不为空" });
            }
            byte[] imgBytes;
            string Value;
            if (value.Contains(";base64"))
            {
                string[] strs = value.Split(',');
                string[] formats = strs[0].Replace(";base64", "").Split(':');
                string img = strs[1];
                string format = formats[1];
                string[] imgFormats = { "image/png", "image/jpg", "image/jpeg", "image/bmp", "IMAGE/PNG", "IMAGE/JPG", "IMAGE/JPEG", "IMAGE/BMP" };               
                if (!imgFormats.Contains(format))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "请选择正确的图片格式，支持png、jpg、jpeg、png格式" });
                }
                string ext = "." + format.Split('/')[1];
                try
                {
                    imgBytes = Convert.FromBase64String(img);
                }
                catch (Exception ex)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "图片解密错误" });
                }
                Value = SaveImg(imgBytes, ext);
            }
            else
            {
                Value = value;
            }            

            if (!settingsService.Update(id, Value))
            {
                return Json(new AjaxResult { Status = "0", Msg = "参数设置出错" });
            }
            return Json(new AjaxResult { Status="1",Data="/admin/system/setlist"});
        }
        private string SaveImg(byte[] imgBytes, string ext)
        {
            string md5 = CommonHelper.GetMD5(imgBytes);
            string path = "/upload/" + DateTime.Now.ToString("yyyy/MM/dd") + "/" + md5 + ext;
            string fullPath = HttpContext.Server.MapPath("" + path);
            new FileInfo(fullPath).Directory.Create();
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(new FixedResizeConstraint(616, 308));//限制图片的大小，避免生成
            jobNormal.SaveProcessedImageToFileSystem(imgBytes, fullPath);
            return path;
        }
        public ActionResult Clear()
        {
            return View();
        }
        [Permission("系统管理")]
        [ActDescription("清测试数据")]        
        public ActionResult ClearData()
        {
            if (dataBaseService.DataBaseClear() < 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "清空失败" });
            }
            return Json(new AjaxResult { Status = "1" });
        }
    }
}