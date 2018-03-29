using CodeCarvings.Piczard;
using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models.News;
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
    /// 公告管理
    /// </summary>
    public class NewsController : AdminBaseController
    {
        #region 属性注入
        public INewsService newService { get; set; }
        #endregion

        #region 列表
        public ActionResult List()
        {
            return View();
        }
        public PartialViewResult ListGetPage(string title, DateTime? startTime, DateTime? endTime, int pageIndex = 1)
        {
            int pageSize = 3;
            NewsListViewModel model = new NewsListViewModel();
            NewsSearchResult result = newService.GetPageList(title, startTime, endTime, pageIndex, pageSize);
            model.News = result.News;

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
            return PartialView("NewsListPaging", model);
        }
        #endregion

        #region 添加
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(NewsAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(MVCHelper.GetJsonValidMsg(ModelState));
            }

            string[] strs = model.ImgURL.Split(',');
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
            try
            {
                long id = newService.AddNew(AdminId, model.Title, SaveImg(imgBytes, ext), model.Contents);
            }
            catch(DbEntityValidationException ex)
            {
                return Json(new AjaxResult { Status = "0", Msg = ex.Message });
            }
            return Json(new AjaxResult { Status = "1", Data = 0 });
        }
        #endregion

        #region 修改
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dto= newService.GetById(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit(NewsEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(MVCHelper.GetJsonValidMsg(ModelState));
            }

            string[] strs = model.ImgURL.Split(',');
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
            try
            {
                newService.Update(model.Id, model.Title, model.Contents, SaveImg(imgBytes, ext));
            }
            catch (DbEntityValidationException ex)
            {
                return Json(new AjaxResult { Status = "0", Msg = ex.Message });
            }
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 删除
        [HttpPost]
        public ActionResult Del(long id)
        {
            newService.Delete(id);
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
                
        public ActionResult UpImg(HttpPostedFileBase file)
        {
            string md5 = CommonHelper.GetMD5(file.InputStream);
            string ext = Path.GetExtension(file.FileName);
            string path = "/upload/" + DateTime.Now.ToString("yyyy/MM/dd") + "/" + md5 + ext;
            string fullPath = HttpContext.Server.MapPath("~" + path);
            new FileInfo(fullPath).Directory.Create();

            file.InputStream.Position = 0;
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(new FixedResizeConstraint(750, 1334));//限制图片的大小，避免生成
            jobNormal.SaveProcessedImageToFileSystem(file.InputStream, fullPath);
            string[] paths = { path };

            return Json(new { errno = "0", Data = paths });
        }

        #region 二进制图片保存，返回地址
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
        #endregion

        public ActionResult Link()
        { 
            return View();
        }
    }
}