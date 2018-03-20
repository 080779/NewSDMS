using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class StockService : IStockService
    {
        public List<StockDTO> GetStockCount()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                List<UserProEntity> list = new List<UserProEntity>();
                CommonService<StockEntity> cs = new CommonService<StockEntity>(dbc);
                return cs.GetAll().ToList().Select(r => new StockDTO
                {
                    UserID = r.UserID,
                    StockID = r.StockID,
                    Amount = r.Amount,
                    BuyPrice = r.BuyPrice,
                    Price = r.Price,
                    Number = r.Number,
                    Surplus = r.Surplus,
                    SplitNum = r.SplitNum,
                    BuyDate = r.BuyDate,
                    IsLock = r.IsLock,
                    IsSell = r.IsSell,
                    SalesType = r.SalesType,
                    IsBack = r.IsBack
                }).ToList();
            }
        }

        public List<StockDTO> GetStockList(int pageIndex, int pageSize)
        {
            int startRow = (pageIndex - 1) * pageSize;
            using (MyDbContext dbc = new MyDbContext())
            {
                List<StockDTO> list = new List<StockDTO>();
                CommonService<StockEntity> cs = new CommonService<StockEntity>(dbc);
                return cs.GetAll().ToList().Skip(startRow).Take(pageSize).Select(r => new StockDTO
                {
                    UserID = r.UserID,
                    StockID = r.StockID,
                    Amount = r.Amount,
                    BuyPrice = r.BuyPrice,
                    Price = r.Price,
                    Number = r.Number,
                    Surplus = r.Surplus,
                    SplitNum = r.SplitNum,
                    BuyDate = r.BuyDate,
                    IsLock = r.IsLock,
                    IsSell = r.IsSell,
                    SalesType=r.SalesType,
                    IsBack=r.IsBack
                }).ToList();
            }
        }
        public long Add(StockDTO model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<StockEntity> cs = new CommonService<StockEntity>(dbc);
                StockEntity usermodel = new StockEntity();
                usermodel.UserID = model.UserID;
                usermodel.StockID = model.StockID;
                usermodel.Price = model.Price;
                usermodel.Number = model.Number;
                usermodel.Surplus = model.Surplus;
                usermodel.BuyDate = model.BuyDate;
                usermodel.IsDeleted = model.IsDeleted;
                usermodel.CreateTime = model.CreateTime;
                dbc.Stock.Add(usermodel);
                dbc.SaveChanges();
                return usermodel.ID;

            }
        }
    }
}
