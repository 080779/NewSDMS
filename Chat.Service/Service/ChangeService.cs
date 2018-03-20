using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class ChangeService : IChangeService
    {
        #region 转账
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ToUserID"></param>
        /// <param name="Amount"></param>
        /// <param name="ChangeType"></param>
        /// <param name="remark"></param>
        /// <param name="remarken"></param>
        /// <param name="toremark"></param>
        /// <param name="toremarken"></param>
        /// <returns></returns>
        public long TransferMonbey(long UserID, long ToUserID, decimal Amount, long ChangeType, string remark, string remarken, string toremark, string toremarken)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<ChangeEntity> change = new CommonService<ChangeEntity>(dbcontext);
                CommonService<UserEntity> user = new CommonService<UserEntity>(dbcontext);
                CommonService<JournalEntity> journal = new CommonService<JournalEntity>(dbcontext);
                //转账表（insert）
                ChangeEntity entity = new ChangeEntity();
                entity.UserID = UserID;
                entity.ToUserType = 0;
                entity.ToUserID = ToUserID;
                entity.Amount = Amount;
                entity.ChangeType = ChangeType;
                entity.ChangeDate = DateTime.Now;
                dbcontext.Change.Add(entity);

                //转账用户（update）
                UserEntity uentity = user.GetById(UserID);
                UserEntity touentity = user.GetById(ToUserID);
                if (ChangeType == 1)
                {
                    uentity.BonusAccount -= Amount;
                    touentity.BonusAccount += Amount;
                }

                //转出明细（insert）
                JournalEntity jentity = new JournalEntity();
                jentity.UserID = UserID;
                jentity.InAmount = 0;
                if (ChangeType == 1)
                {
                    jentity.OutAmount = Amount;
                    jentity.BalanceAmount = uentity.BonusAccount;
                }
                jentity.JournalType = 1;
                jentity.Journal01 = ToUserID;
                jentity.Remark = remark;
                jentity.RemarkEn = remarken;
                dbcontext.Journal.Add(jentity);

                //转入明细（insert）
                JournalEntity tojentity = new JournalEntity();
                tojentity.UserID = ToUserID;
                tojentity.OutAmount = 0;
                if (ChangeType == 1)
                {
                    tojentity.InAmount = Amount;
                    tojentity.BalanceAmount = uentity.BonusAccount;
                }
                tojentity.JournalType = 1;
                tojentity.Journal01 = UserID;
                tojentity.Remark = toremark;
                tojentity.RemarkEn = toremarken;
                dbcontext.Journal.Add(tojentity);

                int re = dbcontext.SaveChanges();
                return re;
            }
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public ChangeDTO[] GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<ChangeEntity> change = new CommonService<ChangeEntity>(dbcontext);
                return change.GetAll().ToList().Select(p => ToDTO(p)).ToArray();
            }
        } 
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="ToUserCode"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ChangePageResult GetPageList(long UserID, string UserCode, string ToUserCode, long ChangeType, DateTime? start, DateTime? end, int pageIndex, int pageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<ChangeEntity> change = new CommonService<ChangeEntity>(dbcontext);
                ChangePageResult pageResult = new ChangePageResult();
                var ChangeQuery = change.GetAll();
                if (UserID > 0)
                {
                    ChangeQuery = ChangeQuery.Where(p => p.UserID == UserID);
                }
                if (!string.IsNullOrEmpty(UserCode))
                {
                    ChangeQuery = ChangeQuery.Where(p => p.UserInfo.UserCode.Contains(UserCode));
                }
                if (ChangeType > 0)
                {
                    ChangeQuery = ChangeQuery.Where(p => p.ChangeType == ChangeType);
                }
                if (!string.IsNullOrEmpty(ToUserCode))
                {
                    ChangeQuery = ChangeQuery.Where(p => p.ToUserInfo.UserCode.Contains(ToUserCode));
                }
                if (start != null)
                {
                    ChangeQuery = ChangeQuery.Where(p => p.CreateTime >= start);
                }
                if (end != null)
                {
                    ChangeQuery = ChangeQuery.Where(p => p.CreateTime <= end);
                }
                pageResult.TotalCount = ChangeQuery.Count();
                pageResult.ChangeList = ChangeQuery.OrderByDescending(p => p.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return pageResult;
            }
        } 
        #endregion

        public ChangeDTO ToDTO(ChangeEntity entity)
        {
            ChangeDTO dto = new ChangeDTO();
            dto.ID = entity.ID;
            dto.UserID = entity.UserID;
            dto.ToUserID = entity.ID;
            dto.Amount = entity.Amount;
            dto.ChangeType = entity.ChangeType;
            dto.ChangeDate = entity.ChangeDate;
            dto.CreateTime = entity.CreateTime;
            dto.UserCode = entity.UserInfo.UserCode;
            dto.TrueName = entity.UserInfo.TrueName;
            dto.ToUserCode = entity.ToUserInfo.UserCode;
            dto.ToTrueName = entity.ToUserInfo.TrueName;
            dto.ChangeTypeName = entity.ChangeTypeInfo.TypeName;
            dto.ChangeTypeNameEn = entity.ChangeTypeInfo.TypeNameEn;
            return dto;
        }
    }
}
