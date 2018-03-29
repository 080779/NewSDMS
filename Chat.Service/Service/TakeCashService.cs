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
                dbc.TakeCashs.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        public int Confirm(long id,string message, string imgUrl, long stateId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                var takeCash = cs.GetAll().SingleOrDefault(t=>t.Id==id);
                if(takeCash==null)
                {
                    return 0;
                }
                if(takeCash.StateId == 1)
                {
                    return -1;
                }
                if(stateId == 1)
                {
                    takeCash.Message = message;
                    takeCash.StateId = stateId;
                    dbc.SaveChanges();
                    return 1;
                }
                else if(stateId == 2)
                {
                    takeCash.ImgUrl = imgUrl;
                    takeCash.StateId = stateId;
                    dbc.SaveChanges();
                    return 2;
                }
                return 1;
            }
        }

        public TakeCashSearchResult GetPageList(string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                TakeCashSearchResult result = new TakeCashSearchResult();
                CommonService<TakeCashEntity> cs = new CommonService<TakeCashEntity>(dbc);
                var takeCashs = cs.GetAll();
                if(takeCashs==null)
                {
                    return result;
                }
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
                if(entity==null)
                {
                    return null;
                }
                return entity.OrderByDescending(t => t.CreateTime).Take(10).ToList().Select(t => ToDTO(t)).ToArray();
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
