using SDMS.DTO.DTO;
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.Stock;
using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class TradingController : FrontBaseController
    {
        public IStockService stockService { get; set; }
        public IUserService UserServer { set; get; }
        
        // GET: Trading
        public ActionResult TradingHall()
        {
            StockView model = new StockView();
            string number = Request.Params["number"];
            string price = Request.Params["price"];
            if (number != null && price != null)
            {
                if(number!="" && price != "")
                {
                    model.StockViewList = stockService.GetStockList(pageIndex, pageSize).Where(r => r.Number == int.Parse(number)).Where(r => r.Price == decimal.Parse(price)).ToList();
                    model.totalPage = stockService.GetStockCount().Where(r => r.Number == int.Parse(number)).Where(r => r.Price == decimal.Parse(price)).ToList().Count;
                }
                else if(number != "" && price == "")
                {
                    model.StockViewList = stockService.GetStockList(pageIndex, pageSize).Where(r => r.Number == int.Parse(number)).ToList();
                    model.totalPage = stockService.GetStockCount().Where(r => r.Number == int.Parse(number)).ToList().Count;
                }
                else if (number == "" && price != "")
                {
                    model.StockViewList = stockService.GetStockList(pageIndex, pageSize).Where(r => r.Price == decimal.Parse(price)).ToList();
                    model.totalPage = stockService.GetStockCount().Where(r => r.Price == decimal.Parse(price)).ToList().Count;
                }
            
            }else if(number== null && price == null)
            {
                model.StockViewList = stockService.GetStockList(pageIndex, pageSize);
                model.totalPage = stockService.GetStockCount().Count;
            }
            for (int i = 0; i < model.StockViewList.Count; i++)
            {
                UserDTO usermodel = UserServer.GetModel(model.StockViewList[i].UserID);
                if (model != null)
                {

                    model.StockViewList[i].UserCode = usermodel.UserCode;
                }
            }
           // model.totalPage = stockService.GetStockCount().Count;
            decimal s = (decimal)model.totalPage / (decimal)pageSize;
            model.showPageNum = int.Parse(Math.Ceiling(s).ToString());
            return View(model);
        }
        public ActionResult Sell()
        {
            ViewBag.UserCode = UserServer.GetModel(9).UserCode;
            ViewBag.Emoney = UserServer.GetModel(9).Emoney;
            return View();
        }
        [HttpPost]
        public ActionResult TradingModel(StockDTO model)
        {
            string msg = "";
            if (model.Number == 0)
            {
                msg = "卖出数量不能为空";
            }
            if (model.Price == 0)
            {
                msg = "卖出价格不能为空";
            }
            UserDTO us = UserServer.GetModel(model.UserCode);
            if (us.Emoney >= model.Number)
            {
                model.StockID = 1;
                model.UserID = Convert.ToInt32(us.ID);
                model.IsDeleted = false;
                model.CreateTime = DateTime.Now;
                model.BuyDate = DateTime.Now;
                model.Surplus = model.Number;
                long Id = stockService.Add(model);
                us.Emoney = us.Emoney - model.Number;
                if (Id > 0 && UserServer.UpdateEmoney(us))
                {
                    msg = "卖出成功";
                }
                else
                {
                    msg = "卖出失败";
                }
            }
            else
            {
                msg = "余额不足";
            }
            
            return Content("<script>alert('" + msg + "');window.location='/Trading/TradingHall';</script>");
        }
    }
}