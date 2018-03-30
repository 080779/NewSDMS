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
                CommonService<SettingsEntity> scs = new CommonService<SettingsEntity>(dbc);
                CommonService<StockItemEntity> cs = new CommonService<StockItemEntity>(dbc);
                CommonService<JournalTypeEntity> jcs = new CommonService<JournalTypeEntity>(dbc);
                StockItemEntity stockItem = cs.GetAll().Where(s=>s.Id==model.StockItemId).SingleOrDefault();
                long holderadd = jcs.GetAll().SingleOrDefault(j => j.Name == "holderadd").Id;
                if (stockItem==null)
                {
                    return -1;
                }

                var seting= scs.GetAll().SingleOrDefault(s=>s.Name == "takecashtime");

                HolderEntity entity = new HolderEntity();
                entity.Amount = model.Amount;
                entity.BankAccount = model.BankAccount;
                entity.BankName = model.BankName;
                entity.Contact = model.Mobile;
                entity.IdNumber = model.IdNumber;
                entity.Mobile = model.Mobile;
                entity.Name = model.Name;
                entity.Gender = model.Gender;
                entity.Proportion = model.Amount / stockItem.TotalAmount;
                entity.TotalAssets = model.Amount;
                entity.Password = model.Password;
                entity.Copies = model.Copies;
                entity.TakeCashTime = entity.CreateTime.AddDays(Convert.ToDouble(seting.Value));

                stockItem.HaveCopies = stockItem.HaveCopies - model.Copies;
                
                JournalEntity journal = new JournalEntity();
                journal.BalanceAmount = entity.TotalAssets;
                journal.InAmount = entity.Amount;
                journal.JournalTypeId = holderadd;
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
        public HolderSearchResult GetPageList(string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
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
                if(!string.IsNullOrEmpty(name))
                {
                    holders = holders.Where(h => h.Name.Contains(name));
                }
                if (!string.IsNullOrEmpty(mobile))
                {
                    holders = holders.Where(h => h.Mobile.Contains(mobile));
                }
                if(startTime!=null)
                {
                    holders = holders.Where(h => h.CreateTime>=startTime);
                }
                if (endTime != null)
                {
                    holders = holders.Where(h => h.CreateTime<=endTime);
                }
                result.TotalCount = holders.LongCount();
                result.Holders = holders.OrderByDescending(h => h.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(h => ToDTO(h)).ToArray();
                return result;
            }
        }

        public HolderDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h=>h.Id==id);
                if(holder==null)
                {
                    return null;
                }
                return ToDTO(holder);
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
            dto.Address = entity.Address;
            dto.Gender = entity.Gender;
            dto.UrgencyContact = entity.UrgencyContact;
            dto.UrgencyName = entity.UrgencyName;
            dto.OpenId = entity.OpenId;
            dto.TakeCashTime = entity.TakeCashTime;
            dto.Copies = entity.Copies;
            return dto;
        }

        public bool Delete(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                CommonService<StockItemEntity> scs = new CommonService<StockItemEntity>(dbc);
                var holder= cs.GetAll().SingleOrDefault(h => h.Id == id);
                if(holder==null)
                {
                    return false;
                }
                var stockItem= scs.GetAll().SingleOrDefault(s => s.KeyName == "project");
                if(stockItem==null)
                {
                    return false;
                }
                stockItem.HaveCopies = stockItem.HaveCopies + holder.Copies;
                holder.IsDeleted = true;
                dbc.SaveChanges();
                return true;
            }
        }

        public decimal ClacAmount(long id,long copies)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<StockItemEntity> cs = new CommonService<StockItemEntity>(dbc);
                var stock = cs.GetAll().SingleOrDefault(h=>h.Id==id);
                if(stock == null)
                {
                    return -1;
                }
                return stock.UnitPrice * copies;
            }
        }

        public bool Update(long id, string address, string contact, string bankAccount, string urgencyName, string urgencyContact)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h => h.Id == id);
                if (holder == null)
                {
                    return false;
                }
                if(!string.IsNullOrEmpty(address))
                {
                    holder.Address = address;
                }
                if (!string.IsNullOrEmpty(contact))
                {
                    holder.Contact = contact;
                }
                if (!string.IsNullOrEmpty(bankAccount))
                {
                    holder.BankAccount = bankAccount;
                }
                if (!string.IsNullOrEmpty(urgencyName))
                {
                    holder.UrgencyName = urgencyName;
                }
                if (!string.IsNullOrEmpty(urgencyContact))
                {
                    holder.UrgencyContact = urgencyContact;
                }                
                dbc.SaveChanges();
                return true;
            }
        }

        public bool Update(long id, string name, string mobile, bool gender, string idNumber, string contact)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h => h.Id == id);
                if (holder == null)
                {
                    return false;
                }
                holder.Name = name;
                holder.Mobile = mobile;
                holder.Gender = gender;
                holder.IdNumber = idNumber;
                holder.Contact = contact;
                dbc.SaveChanges();
                return true;
            }
        }

        public bool CheckOpenId(string openId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h => h.OpenId == openId);
                if(holder==null)
                {
                    return false;
                }
                return true;
            }
        }
        public long GetHoderIdByOpenId(string openId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h => h.OpenId == openId);
                if (holder == null)
                {
                    return -1;
                }
                return holder.Id;
            }
        }
        public long Login(string mobile,string password,string openId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h => h.Mobile == mobile);
                if (holder == null)
                {
                    return -1;
                }
                if(holder.Password!=password)
                {
                    return -2;
                }
                if(!string.IsNullOrEmpty(holder.OpenId))
                {
                    if(holder.OpenId!=openId)
                    {
                        return -3;
                    }
                }
                else
                {
                    holder.OpenId = openId;
                }
                dbc.SaveChanges();
                return holder.Id;
            }
        }
        public long SetTradePwd(long id, string oldTradePwd, string tradePwd)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holer = cs.GetAll().SingleOrDefault(h => h.Id == id);
                if (holer == null)
                {
                    return -1;
                }
                if (string.IsNullOrEmpty(holer.TradePassword))
                {
                    holer.TradePassword = tradePwd;
                }
                if (holer.TradePassword != oldTradePwd)
                {
                    return -2;
                }
                holer.TradePassword = tradePwd;
                dbc.SaveChanges();
                return 1;
            }
        }
        public long UnBind(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                var holder = cs.GetAll().SingleOrDefault(h=>h.Id==id);
                if(holder==null)
                {
                    return -1;
                }
                if(string.IsNullOrEmpty(holder.OpenId))
                {
                    return -2;
                }
                holder.OpenId = null;
                dbc.SaveChanges();
                return 1;
            }
        }

        public HolderCalcNumberDTO CalcNumber()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                CommonService<StockItemEntity> scs = new CommonService<StockItemEntity>(dbc);
                HolderCalcNumberDTO dto = new HolderCalcNumberDTO();
                var holders = cs.GetAll();
                dto.TotalHolder = holders.LongCount();
                dto.TotalHolderAmount = holders.Sum(h => h.Amount);
                dto.TotalHolderBonus = holders.Sum(h => h.TotalBonus);
                dto.TotalProportion = dto.TotalHolderAmount / scs.GetAll().SingleOrDefault(s => s.KeyName == "project").TotalAmount;
                return dto;
            }
        }
    }
}
