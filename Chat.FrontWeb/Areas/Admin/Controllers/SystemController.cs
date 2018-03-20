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

namespace SDMS.Web.Areas.Admin.Controllers
{
    
    public class SystemController : AdminBaseController
    {
        //public IAdminService adminService { get; set; }
        public IRoleService roleService { get; set; }
        public IPermissionService permissionService { get; set; }
        public IGlobeParamService paramService { get; set; }
        public IDataBaseService databaseService { get; set; }
        public IBankNameService banknameService { get; set; }
        public ISystemBankService sysbankService { get; set; }

        #region 管理员管理
        public ActionResult AdminManager()
        {            
            return View();
        }

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

        public ActionResult AdminAdd()
        {
            RoleDTO[] dtos = roleService.GetAll();
            return View(dtos);
        }

        [HttpPost]
        public ActionResult AdminAdd(string userName,string pwd,string spwd,string tpwd,long?[] roleIds)
        {
            if(string.IsNullOrEmpty(userName))
            {
                return Json(new AjaxResult { Status = "0",Msg="用户名不能为空"});
            }
            if(adminService.CheckUserName(userName))
            {
                return Json(new AjaxResult { Status = "0", Msg = "用户名已经存在" });
            }
            if (string.IsNullOrEmpty(pwd))
            {
                return Json(new AjaxResult { Status = "0", Msg = "登录密码不能为空" });
            }
            if (string.IsNullOrEmpty(spwd))
            {
                return Json(new AjaxResult { Status = "0", Msg = "二级密码不能为空" });
            }
            if (string.IsNullOrEmpty(tpwd))
            {
                return Json(new AjaxResult { Status = "0", Msg = "三级密码不能为空" });
            }
            if (roleIds==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色必须选择" });
            }
            long id=adminService.AddNew(userName, pwd, spwd, tpwd, roleIds);
            if(id<=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "管理员用户添加失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/adminmanager" });
        }

        public ActionResult AdminEdit(long id)
        {
            AdminEditViewModel model = new AdminEditViewModel();
            model.Roles= roleService.GetAll();
            model.Admin = adminService.GetById(id);
            List<long> lists = new List<long>();
            foreach(var role in model.Admin.RoleIds)
            {
                lists.Add(role.ID);
            }
            model.RoleIds = lists;
            return View(model);
        }

        [HttpPost]
        public ActionResult AdminEdit(long id, string userName, string pwd, string spwd, string tpwd, long?[] roleIds)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Json(new AjaxResult { Status = "0", Msg = "用户名不能为空" });
            }
            if(roleIds==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色必须选择" });
            }
            if (!adminService.Update(id, userName, pwd, spwd, tpwd, roleIds))
            {
                return Json(new AjaxResult { Status = "0", Msg = "管理员用户编辑失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/adminmanager" });
        }

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
        public ActionResult RoleManager()
        {
            RoleDTO[] dtos= roleService.GetAll();
            return View(dtos);
        }

        public ActionResult RoleAdd()
        {
            RoleAddViewModel model = new RoleAddViewModel();

            List<Permissions> MenuList = new List<Permissions>();
            foreach (var parent in permissionService.GetByParentId(0))
            {
                Permissions parentList = new Permissions();
                parentList.Parent = parent;
                if (permissionService.GetByParentId((long)parent.TypeID) == null)
                {
                    continue;
                }
                parentList.Child = permissionService.GetByParentId((long)parent.TypeID);
                MenuList.Add(parentList);
            }
            model.PermissionList = MenuList;
            return View(model);
        }

        [HttpPost]
        public ActionResult RoleAdd(string name,string description ,long?[] permissionIds)
        {
            if(string.IsNullOrEmpty(name))
            {
                return Json(new AjaxResult { Status = "0", Msg="角色名不能为空" });
            }
            if (string.IsNullOrEmpty(description))
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色描述不能为空" });
            }
            if(permissionIds==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择权限项" });
            }
            if (roleService.AddNew(name,description,permissionIds)<=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色添加失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/rolemanager" });
        }

        public ActionResult RoleEdit(long id)
        {
            RoleEditViewModel model = new RoleEditViewModel();

            List<Permissions> MenuList = new List<Permissions>();
            foreach (var parent in permissionService.GetByParentId(0))
            {
                Permissions parentList = new Permissions();
                parentList.Parent = parent;
                if (permissionService.GetByParentId((long)parent.TypeID) == null)
                {
                    continue;
                }
                parentList.Child = permissionService.GetByParentId((long)parent.TypeID);
                MenuList.Add(parentList);
            }
            model.PermissionList = MenuList;     
            model.PermissionIds = permissionService.GetByRoleId(id);
            model.Role = roleService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult RoleEdit(long? id,string name, string description, long?[] permissionIds)
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
            if (permissionIds == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请选择权限项" });
            }
            if (!roleService.Update((long)id,name, description, permissionIds))
            {
                return Json(new AjaxResult { Status = "0", Msg = "角色编辑失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/rolemanager" });
        }

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

        #region 参数设置
        public ActionResult ParamManager()
        {
            var paramlist= paramService.GetAll();
            return View(paramlist);
        }

        public ActionResult ParamEdit(long? id, string paramVarchar)
        {
            if (id == null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "数据不存在" });
            }
            if (string.IsNullOrEmpty(paramVarchar))
            {
                return Json(new AjaxResult { Status = "0", Msg = "参数不能为空" });
            }
            GlobeParamDTO dto = paramService.GetById(id);
            string strRemark = dto.Remark.Replace("</font>", "").Replace("<font style=\"color:#FF0000;\">", "").Replace("&gt;", ">");
            decimal d;
            int i;
            if (dto.ParamType == 1)
            {
                if(!decimal.TryParse(paramVarchar,out d))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "参数格式错误[" + strRemark + "]" ,Data=dto.ParamVarchar });                                       
                }
                if (d < 0)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "请输入大于等于0的参数[" + strRemark + "]" , Data = dto.ParamVarchar });
                }
            }
            else if (dto.ParamType == 2)
            {
                if (!int.TryParse(paramVarchar, out i))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "请输入整数[" + strRemark + "]", Data = dto.ParamVarchar });
                }
                if(i<0)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "请输入大于等于0的参数[" + strRemark + "]", Data = dto.ParamVarchar });
                }
            }
            else if (dto.ParamType == 3)
            {
                if (!decimal.TryParse(paramVarchar, out d))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "参数格式错误[" + strRemark + "]", Data = dto.ParamVarchar });
                }
                if(d>100)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "比率不能大于100%的参数[" + strRemark + "]", Data = dto.ParamVarchar });
                }
                if (d < 0)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "请输入大于等于0的参数[" + strRemark + "]", Data = dto.ParamVarchar });
                }
            }
            else if (dto.ParamType == 4)
            {
                
            }
            if (!paramService.Update(id, paramVarchar))
            {
                return Json(new AjaxResult { Status = "0", Msg = "参数更新出错" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/parammanager" });
        }

        public ActionResult ParamEditAll(string[]  paramList)
        {
            foreach(var param in paramList)
            {
                string[] paramStrs = param.Split('^');
                long id = Convert.ToInt64(paramStrs[0]);
                string paramVarchar = paramStrs[1];

                GlobeParamDTO dto = paramService.GetById(id);
                string strRemark = dto.Remark.Replace("</font>", "").Replace("<font style=\"color:#FF0000;\">", "").Replace("&gt;", ">");
                decimal d;
                int i;
                if (dto.ParamType == 1)
                {
                    if (!decimal.TryParse(paramVarchar, out d))
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "参数格式错误[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                    if (d < 0)
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "请输入大于等于0的参数[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                }
                else if (dto.ParamType == 2)
                {
                    if (!int.TryParse(paramVarchar, out i))
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "请输入整数[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                    if (i < 0)
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "请输入大于等于0的参数[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                }
                else if (dto.ParamType == 3)
                {
                    if (!decimal.TryParse(paramVarchar, out d))
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "参数格式错误[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                    if (d > 100)
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "比率不能大于100%的参数[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                    if (d < 0)
                    {
                        return Json(new AjaxResult { Status = "0", Msg = "请输入大于等于0的参数[" + strRemark + "]", Data = new { Id=id,ParamVarchar= dto.ParamVarchar } });
                    }
                }
                else if (dto.ParamType == 4)
                {

                }

                if (!paramService.Update(id, paramVarchar))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "参数更新出错" });
                }
            }            
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/parammanager" });
        }
        #endregion

        #region 数据库设置
        public ActionResult DataBaseManager()
        {
            return View();
        }

        public ActionResult Clear()
        {
            if(databaseService.DataBaseClear()<0)
            {
                return Json(new AjaxResult { Status = "0",Msg="清空失败" });
            }
            return Json(new AjaxResult { Status = "1"});
        }
        #endregion

        #region 银行设置
        public ActionResult BankNameManage()
        {
            BankNameListModel model = new BankNameListModel();
            model.bankList = banknameService.GetList();
            return View(model);
        }

        public ActionResult AddBankName(string bankname, string banknameen)
        {
            long id = banknameService.AddBankName(bankname, banknameen);
            if (id > 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "添加失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/BankNameManage" });
        }

        public ActionResult BankNameDel(long id)
        {
            long i = banknameService.Delete(id);
            if (i == 1)
            {
                return Json(new AjaxResult { Status = "0", Msg = "删除失败" });
            }
            else if (i == 2)
            {
                return Json(new AjaxResult { Status = "0", Msg = "已删除" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/BankNameManage" });
        }
        #endregion

        #region 系统账户设置
        public ActionResult SystemBankManage()
        {
            SystemBankListModel model = new SystemBankListModel();
            model.sysbankList = sysbankService.GetList();
            return View(model);
        }

        public ActionResult AddSystemBank(string bankname, string bankaccount, string bankaccountuser)
        {
            long id = sysbankService.AddSystemBank(bankname, bankaccount, bankaccountuser, "", 0);
            if (id > 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "添加失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/SystemBankManage" });
        }

        public ActionResult SystemBankDel(long id)
        {
            long i = sysbankService.Delete(id);
            if (i == 1)
            {
                return Json(new AjaxResult { Status = "0", Msg = "删除失败" });
            }
            else if (i == 2)
            {
                return Json(new AjaxResult { Status = "0", Msg = "已删除" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/system/SystemBankManage" });
        }
        #endregion
    }
}