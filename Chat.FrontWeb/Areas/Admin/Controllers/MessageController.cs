using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class MessageController : AdminBaseController
    {
        #region 属性注入
        public IMessageService messageService { get; set; }
        #endregion

        #region 列表

        [ActDescription("留言列表")]

        public ActionResult List()
        {
            return View();
        }
        public PartialViewResult ListGetPage(long? holderId, string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex=1)
        {
            int pageSize = 3;
            MessageListViewModel model = new MessageListViewModel();
            MessageSearchResult result = messageService.GetPageList(holderId, name, mobile, startTime, endTime, pageIndex, pageSize);
            model.Messages = result.Messages;

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
            return PartialView("MessageListPaging", model);
        }
        #endregion
    }
}