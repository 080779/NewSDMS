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
    public class RechargeService : IRechargeService
    {
        #region 添加后台充值记录
        /// <summary>
        /// 添加后台充值记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Amount"></param>
        /// <param name="YuAmount"></param>
        /// <param name="RechargeType"></param>
        /// <param name="RechargeStyle"></param>
        /// <returns></returns>
        public long Add(long UserID, decimal Amount, decimal YuAmount, int RechargeType, int RechargeStyle)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                RechargeEntity rechargeModel = new RechargeEntity();
                rechargeModel.UserID = UserID;
                rechargeModel.RechargeableMoney = Amount;
                rechargeModel.RechargeDate = DateTime.Now;
                rechargeModel.YuAmount = YuAmount;
                rechargeModel.RechargeType = RechargeType;
                rechargeModel.RechargeStyle = RechargeStyle;
                rechargeModel.Flag = 1;
                dbcontext.Recharge.Add(rechargeModel);
                dbcontext.SaveChanges();
                return rechargeModel.ID;
            }
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<RechargeDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<RechargeEntity> csr = new CommonService<RechargeEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserCode"></param>
        /// <param name="TrueName"></param>
        /// <param name="RechargeType">币种</param>
        /// <param name="RechargeStyle">充值类型</param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public RechargePageResult GetPageList(long UserID, string UserCode, string TrueName, int RechargeType, int RechargeStyle, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<RechargeEntity> csr = new CommonService<RechargeEntity>(dbcontext);
                RechargePageResult PageResult = new RechargePageResult();
                var RechargeQuery = csr.GetAll();

                if (UserID > 0)
                {
                    RechargeQuery = RechargeQuery.Where(p => p.UserID == UserID);
                }
                if (!string.IsNullOrEmpty(UserCode))
                {
                    RechargeQuery = RechargeQuery.Where(p => p.Users.UserCode.Contains(UserCode));
                }
                if (!string.IsNullOrEmpty(TrueName))
                {
                    RechargeQuery = RechargeQuery.Where(p => p.Users.TrueName.Contains(TrueName));
                }
                if (RechargeType > 0)//币种
                {
                    RechargeQuery = RechargeQuery.Where(p => p.RechargeType == RechargeType);
                }
                if (RechargeStyle > 0)//充值类型
                {
                    RechargeQuery = RechargeQuery.Where(p => p.RechargeStyle == RechargeStyle);
                }
                if (StartTime != null)
                {
                    RechargeQuery = RechargeQuery.Where(p => p.RechargeDate >= StartTime);
                }
                if (EndTime != null)
                {
                    RechargeQuery = RechargeQuery.Where(p => p.RechargeDate <= EndTime);
                }
                PageResult.Recharges = RechargeQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                PageResult.TotalCount = RechargeQuery.LongCount();

                return PageResult;
            }
        }
        #endregion

        public RechargeDTO ToDTO(RechargeEntity recharge)
        {
            RechargeDTO reDTO = new RechargeDTO();
            reDTO.ID = recharge.ID;
            reDTO.UserID = recharge.UserID;
            reDTO.RechargeableMoney = recharge.RechargeableMoney;
            reDTO.AgentID = recharge.AgentID;
            reDTO.YuAmount = recharge.YuAmount;
            reDTO.Flag = recharge.Flag;
            reDTO.RechargeDate = recharge.RechargeDate;
            reDTO.Recharge001 = recharge.Recharge001;
            reDTO.Recharge002 = recharge.Recharge002;
            reDTO.Recharge003 = recharge.Recharge003;
            reDTO.Recharge004 = recharge.Recharge004;
            reDTO.Recharge005 = recharge.Recharge005;
            reDTO.Recharge006 = recharge.Recharge006;
            reDTO.UserCode = recharge.Users.UserCode;
            reDTO.TrueName = recharge.Users.TrueName;
            reDTO.CurrencyName = recharge.CurrencyNames.CurrencyName;
            reDTO.CurrencyNameEn = recharge.CurrencyNames.CurrencyNameEn;
            reDTO.StyleName = recharge.RechargeStyle == 1 ? "增加" : "减少";

            return reDTO;
        }
    }
}
