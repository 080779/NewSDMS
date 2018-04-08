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
    public class TakeCashService : ITakeCashService
    {
        public long Apply(long holderId, decimal Amount)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                CommonService<TakeCashStateEntity> tcs = new CommonService<TakeCashStateEntity>(dbc);
                long stateId = tcs.GetAll().SingleOrDefault(t=>t.Name== "正在处理").Id;
                var holder = cs.GetAll().SingleOrDefault(h => h.Id == holderId);
                if (holder == null)
                {
                    return -2;
                }
                if (holder.TakeBonus < Amount)
                {
                    return -1;
                }
                TakeCashEntity entity = new TakeCashEntity();
                entity.Amount = Amount;
                entity.HolderId = holderId;
                entity.StateId = stateId;
                dbc.TakeCashs.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        public bool Confirm(long id,string imgUrl)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                CommonService<TakeCashStateEntity> tcs = new CommonService<TakeCashStateEntity>(dbc);
                CommonService<HolderEntity> hcs = new CommonService<HolderEntity>(dbc);
                CommonService<JournalTypeEntity> jcs = new CommonService<JournalTypeEntity>(dbc);
                var takeCash = cs.GetAll().SingleOrDefault(t=>t.Id==id);
                if(takeCash==null)
                {
                    return false;
                }
                var holder = hcs.GetAll().SingleOrDefault(h=>h.Id==takeCash.HolderId);
                if(holder==null)
                {
                    return false;
                }
                takeCash.ImgUrl = imgUrl;
                takeCash.StateId = tcs.GetAll().SingleOrDefault(t => t.Name == "已完成").Id;
                holder.TakeBonus = holder.TakeBonus - takeCash.Amount;
                holder.HaveBonus = holder.HaveBonus + takeCash.Amount;
                JournalEntity journal = new JournalEntity();
                journal.BalanceAmount = holder.TakeBonus;
                journal.HolderId = holder.Id;
                journal.OutAmount = takeCash.Amount;
                journal.Remark = "提现";
                journal.JournalTypeId = jcs.GetAll().SingleOrDefault(j => j.Name == "takecash").Id;
                dbc.Journal.Add(journal);
                dbc.SaveChanges();
                return true;
            }
        }
        public bool Reject(long id, string message)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                CommonService<TakeCashStateEntity> tcs = new CommonService<TakeCashStateEntity>(dbc);
                var takeCash = cs.GetAll().SingleOrDefault(t => t.Id == id);
                if (takeCash == null)
                {
                    return false;
                }
                takeCash.Message = message;
                takeCash.StateId = tcs.GetAll().SingleOrDefault(t => t.Name == "被驳回").Id;
                dbc.SaveChanges();
                return true;
            }
        }

        public TakeCashSearchResult GetPageList(string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                TakeCashSearchResult result = new TakeCashSearchResult();
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                var takeCashs = cs.GetAll();
                if(!string.IsNullOrEmpty(name))
                {
                    takeCashs = takeCashs.Where(t=>t.Holder.Name.Contains(name));
                }
                if (!string.IsNullOrEmpty(mobile))
                {
                    takeCashs = takeCashs.Where(t => t.Holder.Mobile.Contains(mobile));
                }
                if (startTime != null)
                {
                    takeCashs = takeCashs.Where(t => t.CreateTime >= startTime);
                }
                if (endTime != null)
                {
                    takeCashs = takeCashs.Where(t => t.CreateTime <= endTime);
                }
                result.TotalCount = takeCashs.LongCount();
                result.TakeCashs=takeCashs.OrderByDescending(t => t.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(t => ToDTO(t)).ToArray();
                return result;
            }
        }

        public TakeCashDTO[] GetByHolderId(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                var entity = cs.GetAll().Where(t=>t.HolderId==id);
                return entity.OrderByDescending(t => t.CreateTime).Take(10).ToList().Select(t => ToDTO(t)).ToArray();
            }
        }

        public TakeCashDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(t => t.Id == id);
                if (entity == null)
                {
                    return null;
                }
                return ToDTO(entity);
            }
        }
                
        public TakeCashDTO ToDTO(TakeCashEntity entity)
        {
            TakeCashDTO dto = new TakeCashDTO();
            dto.Amount = entity.Amount;
            dto.CreateTime = entity.CreateTime;
            dto.StateId = entity.StateId;
            dto.TakeCashStateName = entity.State.Name;
            dto.HolderBankAccount = entity.Holder.BankAccount;
            dto.HolderHaveBonus = entity.Holder.HaveBonus;
            dto.HolderName = entity.Holder.Name;
            dto.HolderTakeBonus = entity.Holder.TakeBonus;
            dto.HolderTotalBonus = entity.Holder.TotalBonus;
            dto.Id = entity.Id;
            dto.ImgUrl = entity.ImgUrl;
            dto.Message = entity.Message;
            dto.Poundage = entity.Poundage;
            return dto;
        }
    }
}
