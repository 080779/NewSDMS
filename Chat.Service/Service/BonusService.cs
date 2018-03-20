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
    public class BonusService : IBonusService
    {
        #region 添加奖项记录
        /// <summary>
        /// 添加奖项记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="TypeID"></param>
        /// <param name="Amount"></param>
        /// <param name="Sf"></param>
        /// <param name="Revenue"></param>
        /// <param name="IsSettled"></param>
        /// <param name="Remark"></param>
        /// <param name="RemarkEn"></param>
        /// <returns></returns>
        public long Add(long UserID, int TypeID, decimal Amount, decimal Sf, decimal Revenue, int IsSettled, string Remark, string RemarkEn)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                BonusEntity model = new BonusEntity();
                model.UserID = UserID;
                model.TypeID = TypeID;
                model.Amount = Amount;
                model.Revenue = Revenue;
                model.Sf = Sf;
                model.AddTime = DateTime.Now;
                model.IsSettled = IsSettled;
                model.Source = Remark;
                model.SourceEn = RemarkEn;
                dbcontext.Bonus.Add(model);
                dbcontext.SaveChanges();
                return model.ID;
            }
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<BonusDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<BonusEntity> csr = new CommonService<BonusEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion

        #region 分页查询

        public BonusPageResult GetPageList(long UserID, string UserCode, string TrueName, int TypeID, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<BonusEntity> csr = new CommonService<BonusEntity>(dbcontext);
                BonusPageResult PageResult = new BonusPageResult();
                var JournalQuery = csr.GetAll();

                if (UserID > 0)
                {
                    JournalQuery = JournalQuery.Where(p => p.UserID == UserID);
                }
                if (!string.IsNullOrEmpty(UserCode))
                {
                    JournalQuery = JournalQuery.Where(p => p.Users.UserCode.Contains(UserCode));
                }
                if (!string.IsNullOrEmpty(TrueName))
                {
                    JournalQuery = JournalQuery.Where(p => p.Users.TrueName.Contains(TrueName));
                }
                if (TypeID > 0)
                {
                    JournalQuery = JournalQuery.Where(p => p.TypeID == TypeID);
                }
                if (StartTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime >= StartTime);
                }
                if (EndTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime <= EndTime);
                }
                PageResult.BonusS = JournalQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                PageResult.TotalCount = JournalQuery.LongCount();

                return PageResult;
            }
        }
        #endregion

        public BonusDTO ToDTO(BonusEntity model)
        {
            BonusDTO dto = new BonusDTO();
            dto.ID = model.ID;
            dto.UserID = model.UserID;
            dto.TypeID = model.TypeID;
            dto.Amount = model.Amount;
            dto.Sf = model.Sf;
            dto.Revenue = model.Revenue;
            dto.AddTime = model.AddTime;
            dto.IsSettled = model.IsSettled;
            dto.SttleTime = model.SttleTime;
            dto.Bonus001 = model.Bonus001;
            dto.Bonus002 = model.Bonus002;
            dto.Bonus003 = model.Bonus003;
            dto.Bonus004 = model.Bonus004;
            dto.Bonus005 = model.Bonus005;
            dto.Bonus006 = model.Bonus006;
            dto.Bonus007 = model.Bonus007;
            dto.UserCode = model.Users.UserCode;
            dto.TrueName = model.Users.TrueName;
            dto.TypeName = model.BonusTypes.TypeName;
            dto.TypeNameEn = model.BonusTypes.TypeNameEn;
            dto.SettleName = model.IsSettled == 0 ? "未结算" : "已结算";
            return dto;
        }

    }
}
