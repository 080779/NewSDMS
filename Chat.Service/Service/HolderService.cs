using SDMS.DTO.DTO;
using SDMS.DTO.Model;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class HolderService : IHolderService
    {
        public long AddNew(HolderSvcModel model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<StockItemEntity> cs = new CommonService<StockItemEntity>(dbc);
                StockItemEntity stockItem = cs.GetAll().Where(s=>s.Id==model.StockItemId).SingleOrDefault();
                if(stockItem==null)
                {
                    return -1;
                }

                HolderEntity entity = new HolderEntity();
                entity.Amount = model.Amount;
                entity.BankAccount = model.BankAccount;
                entity.BankName = model.BankName;
                entity.Contact = model.Mobile;
                entity.IdNumber = model.IdNumber;
                entity.Mobile = model.Mobile;
                entity.Name = model.Name;
                entity.Proportion = model.Amount / stockItem.TotalAmount;
                entity.TotalAssets = model.Amount;
                entity.Password = model.Password;
                
                JournalEntity journal = new JournalEntity();
                journal.BalanceAmount = entity.TotalAssets;
                journal.InAmount = entity.Amount;
                journal.JournalTypeId = 1;
                journal.Remark = "后台添加股东";

                dbc.Holder.Add(entity);
                dbc.Journal.Add(journal);
                dbc.SaveChanges();
                return entity.Id;
            }
        }
        public bool Update(HolderSvcModel model)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                CommonService<StockItemEntity> scs = new CommonService<StockItemEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h => h.Id == model.Id);
                var stockItem = scs.GetAll().SingleOrDefault(s => s.Id == model.StockItemId);
                if(holder==null)
                {
                    return false;
                }
                if(stockItem==null)
                {
                    return false;
                }
                JournalEntity journal = new JournalEntity();
                if (model.Flag)
                {
                    holder.Amount = holder.Amount + model.Amount;
                    holder.BankAccount = model.BankAccount;
                    holder.BankName = model.BankName;
                    holder.Contact = model.Contact;
                    holder.IdNumber = model.IdNumber;
                    holder.Mobile = model.Mobile;
                    holder.Name = model.Name;
                    holder.Password = model.Password;
                    holder.Proportion = holder.Amount / stockItem.TotalAmount;
                    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;
                    
                    journal.BalanceAmount = holder.TotalAssets;
                    journal.InAmount = model.Amount;
                    journal.JournalTypeId = 1;
                    journal.Remark = "后台编辑添加股东股份";
                }
                else
                {
                    holder.Amount = holder.Amount - model.Amount;
                    holder.BankAccount = model.BankAccount;
                    holder.BankName = model.BankName;
                    holder.Contact = model.Contact;
                    holder.IdNumber = model.IdNumber;
                    holder.Mobile = model.Mobile;
                    holder.Name = model.Name;
                    holder.Password = model.Password;
                    holder.Proportion = holder.Amount / stockItem.TotalAmount;
                    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;

                    journal.BalanceAmount = holder.TotalAssets;
                    journal.InAmount = model.Amount;
                    journal.JournalTypeId = 1;
                    journal.Remark = "后台编辑减少股东股份";
                }

                dbc.Journal.Add(journal);
                dbc.SaveChanges();
                return true;
            }
        }
        public HolderSearchResult GetPageList(int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                HolderSearchResult result = new HolderSearchResult();
                var holders = cs.GetAll();
                if(holders==null)
                {
                    return result;
                }
                result.TotalCount = holders.LongCount();
                result.Holders = holders.OrderByDescending(h => h.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(h => ToDTO(h)).ToArray();
                return result;
            }
        }

        public HolderDTO ToDTO(HolderEntity entity)
        {
            HolderDTO dto = new HolderDTO();
            dto.Amount = entity.Amount;
            dto.BankAccount = entity.BankAccount;
            dto.BankName = entity.BankName;
            dto.Contact = entity.Contact;
            dto.CreateTime = entity.CreateTime;
            dto.HaveBonus = entity.HaveBonus;
            dto.Id = entity.Id;
            dto.IdNumber = entity.IdNumber;
            dto.Mobile = entity.Mobile;
            dto.Name = entity.Name;
            dto.Proportion = entity.Proportion;
            dto.TakeBonus = entity.TakeBonus;
            dto.TotalAssets = entity.TotalAssets;
            dto.TotalBonus = entity.TotalBonus;
            dto.TradePassword = entity.TradePassword;
            return dto;
        }
        
    }
}
