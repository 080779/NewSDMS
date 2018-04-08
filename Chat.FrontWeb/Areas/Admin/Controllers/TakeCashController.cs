using CodeCarvings.Piczard;
using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models.TakeCash;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 提现管理
    /// </summary>
    public class TakeCashController : AdminBaseController
    {
        #region 属性注入
        public ITakeCashService takeCashService { get; set; }
        public IJournalService journalService { get; set; }
        public IJournalTypeService journalTypeService { get; set; }
        public IHolderService holderService { get; set; }
        #endregion

        #region 提现申请管理
        //申请列表
        [Permission("提现管理")]
        [ActDescription("提现申请列表")]
        public ActionResult Apply()
        {
            return View();
        }
        [Permission("提现管理")]
        public PartialViewResult ApplyGetPage(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex = 1)
        {
            int pageSize = 3;
            TakeCashViewModel model = new TakeCashViewModel();
            TakeCashSearchResult result = takeCashService.GetPageList(name,mobile,startTime,endTime,pageIndex, pageSize);
            model.TakeCashes = result.TakeCashs;

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
            return PartialView("TakeCashApplyPaging", model);
        }

        //确认申请
        [HttpGet]
        [Permission("提现管理")]        
        public ActionResult Confirm(long id)
        {
            return View(id);
        }
        [HttpPost]
        [Permission("提现管理")]
        [ActDescription("提现确认")]
        public ActionResult Confirm(long id,string imgUrl)
        {
            if(string.IsNullOrEmpty(imgUrl))
            {
                if (!takeCashService.Confirm(id,imgUrl))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "提现申请确认失败" });
                }
            }
            else
            {
                string[] strs = imgUrl.Split(',');
                string[] formats = strs[0].Replace(";base64", "").Split(':');
                string img = strs[1];
                string format = formats[1];
                string[] imgFormats = { "image/png", "image/jpg", "image/jpeg", "image/bmp", "IMAGE/PNG", "IMAGE/JPG", "IMAGE/JPEG", "IMAGE/BMP" };
                byte[] imgBytes;
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
                if (!takeCashService.Confirm(id, SaveImg(imgBytes, ext)))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "提现申请确认失败" });
                }
            }            
            return Json(new AjaxResult { Status = "1",Data="/admin/takecash/apply" });
        }
        private string SaveImg(byte[] imgBytes, string ext)
        {
            string md5 = CommonHelper.GetMD5(imgBytes);
            string path = "/upload/" + DateTime.Now.ToString("yyyy/MM/dd") + "/" + md5 + ext;
            string fullPath = HttpContext.Server.MapPath("" + path);
            new FileInfo(fullPath).Directory.Create();
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(new FixedResizeConstraint(750, 1334));//限制图片的大小，避免生成
            jobNormal.SaveProcessedImageToFileSystem(imgBytes, fullPath);
            return path;
        }
        //驳回
        [HttpGet]
        [Permission("提现管理")]
        public ActionResult Reject(long id)
        {            
            return View(id);
        }
        [HttpPost]
        [Permission("提现管理")]
        [ActDescription("提现驳回")]
        public ActionResult Reject(long id,string message)
        {
            if(! takeCashService.Reject(id, message))
            {
                return Json(new AjaxResult { Status = "0", Msg = "驳回申请失败" });
            }
            return Json(new AjaxResult { Status = "1",Data="/admin/takecash/apply" });
        }
        #endregion

        #region 提现统计
        [Permission("提现管理")]
        [ActDescription("提现流水列表")]
        public ActionResult TakeCashJournal()
        {
            var model=holderService.TakeCashCalcNumber();
            return View(model);
        }
        [Permission("提现管理")]
        public PartialViewResult TakeCashJournalGetPage(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex=1)
        {
            TakeCashJournalModel model = new TakeCashJournalModel();
            long journalTypeId = journalTypeService.GetByDecription("提现").First().Id;
            JournalPageResult result = journalService.GetPageList(null, mobile, name, null, journalTypeId, startTime, endTime, pageIndex, pageSize);
            model.Journals = result.Journals;

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
            return PartialView("TakeCashJournalPaging", model);
        }
        #endregion

        #region 提现设置 在参数设置里设置了
        //[HttpGet]
        //[Permission("提现管理")]
        //public ActionResult SetUp()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[Permission("提现管理")]
        //[ActDescription("提现设置")]
        //public ActionResult SetUp(string s)
        //{
        //    return Json(new AjaxResult { Status = "1" });
        //}
        #endregion
    }
}