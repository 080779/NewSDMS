using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class StockItemService : IStockItemService
    {
        public long AddNew(string name, string description, decimal totalAmount, long totalCopies, long issueCopies)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                StockItemEntity entity = new StockItemEntity();
                entity.Name = name;
                entity.Description = description;
                entity.TotalAmount = totalAmount;
                entity.TotalCopies = totalCopies;
                entity.IssueCopies = issueCopies;
                entity.UnitPrice = entity.TotalAmount / entity.TotalCopies;
                dbc.StockItems.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<StockItemEntity> cs = new CommonService<StockItemEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s=>s.Id==id);
                if(entity==null)
                {
                    return false;
                }
                entity.IsDeleted = true;
                dbc.SaveChanges();
                return true;
            }
        }

        public StockItemDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<StockItemEntity> cs = new CommonService<StockItemEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s=>s.Id==id);
                if(entity==null)
                {
                    return null;
                }
                return new StockItemDTO { CreateTime = entity.CreateTime, Description = entity.Description, Id = entity.Id, IssueCopies = entity.IssueCopies, Name = entity.Name, TotalAmount = entity.TotalAmount, TotalCopies = entity.TotalCopies, UnitPrice = entity.UnitPrice, HaveCopies=entity.HaveCopies};
            }
        }

        public bool Update(long id, string name, string description, decimal totalAmount, long totalCopies, long issueCopies)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<StockItemEntity> cs = new CommonService<StockItemEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s => s.Id == id);
                if (entity == null)
                {
                    return false;
                }
                entity.Name = name;
                entity.Description = description;
                entity.TotalAmount = totalAmount;
                entity.TotalCopies = totalCopies;
                entity.IssueCopies = issueCopies;
                entity.UnitPrice = entity.TotalAmount / entity.TotalCopies;
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
