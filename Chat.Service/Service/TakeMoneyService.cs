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
    public class TakeMoneyService : ITakeMoneyService
    {
        #region 添加提现记录
        /// <summary>
        /// 添加提现记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Amount"></param>
        /// <param name="Cyjj"></param>
        /// <param name="Fee"></param>
        /// <param name="Flag"></param>
        /// <param name="BankName"></param>
        /// <param name="BankAccount"></param>
        /// <param name="BankAccountUser"></param>
        /// <returns></returns>
        public long Add(long UserID, decimal Amount, decimal Cyjj, decimal Fee, int Flag, string BankName, string BankAccount, string BankAccountUser)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                TakeMoneyEntity takeModel = new TakeMoneyEntity();
                takeModel.UserID = UserID;
                takeModel.TakeMoney = Amount;
                takeModel.TakePoundage = Cyjj;
                takeModel.Take005 = Fee;
                takeModel.RealityMoney = Amount - Cyjj - Fee;
                takeModel.BankName = BankName;
                takeModel.BankAccount = BankAccount;
                takeModel.BankAccountUser = BankAccountUser;
                takeModel.Flag = Flag;
                takeModel.TakeTime = DateTime.Now;
                dbcontext.TakeMoney.Add(takeModel);
                dbcontext.SaveChanges();
                return takeModel.ID;
            }
        }
        #endregion

        #region 更新提现记录状态
        /// <summary>
        /// 更新提现记录状态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public int UpdateFlag(long ID, int Flag)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<TakeMoneyEntity> csr = new CommonService<TakeMoneyEntity>(dbcontext);
                TakeMoneyEntity takeModel = csr.GetById(ID);
                if (takeModel == null)
                {
                    return 2;//已删除
                }
                if (takeModel.Flag == 1)
                {
                    return 3;//已确认
                }
                takeModel.Flag = Flag;
                takeModel.Take006 = DateTime.Now;
                int num = dbcontext.SaveChanges();
                if (num > 0)
                {
                    return 0;//确认成功
                }
                else
                {
                    return 1;//确认失败
                }
            }
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<TakeMoneyDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<TakeMoneyEntity> csr = new CommonService<TakeMoneyEntity>(dbcontext);
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
        /// <param name="Flag"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public TakeMoneyPageResult GetPageList(long UserID, string UserCode, string TrueName, int Flag, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<TakeMoneyEntity> csr = new CommonService<TakeMoneyEntity>(dbcontext);
                TakeMoneyPageResult PageResult = new TakeMoneyPageResult();
                var TakeMoneyQuery = csr.GetAll();

                if (UserID > 0)
                {
                    TakeMoneyQuery = TakeMoneyQuery.Where(p => p.UserID == UserID);
                }
                if (!string.IsNullOrEmpty(UserCode))
                {
                    TakeMoneyQuery = TakeMoneyQuery.Where(p => p.Users.UserCode.Contains(UserCode));
                }
                if (!string.IsNullOrEmpty(TrueName))
                {
                    TakeMoneyQuery = TakeMoneyQuery.Where(p => p.Users.TrueName.Contains(TrueName));
                }
                if (Flag > -1)
                {
                    TakeMoneyQuery = TakeMoneyQuery.Where(p => p.Flag == Flag);
                }
                if (StartTime != null)
                {
                    TakeMoneyQuery = TakeMoneyQuery.Where(p => p.TakeTime >= StartTime);
                }
                if (EndTime != null)
                {
                    TakeMoneyQuery = TakeMoneyQuery.Where(p => p.TakeTime <= EndTime);
                }
                PageResult.TakeMoneys = TakeMoneyQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                PageResult.TotalCount = TakeMoneyQuery.LongCount();

                return PageResult;
            }
        }
        #endregion

        #region 根据ID查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public TakeMoneyDTO GetModelByID(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<TakeMoneyEntity> csr = new CommonService<TakeMoneyEntity>(dbcontext);
                TakeMoneyEntity take = csr.GetById(ID);
                TakeMoneyDTO model = null;
                if (take != null)
                {
                    model = ToDTO(take);
                }
                return model;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Del(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<TakeMoneyEntity> csr = new CommonService<TakeMoneyEntity>(dbcontext);
                TakeMoneyEntity re = csr.GetById(ID);
                if (re != null)
                {
                    re.IsDeleted = true;
                    int num = dbcontext.SaveChanges();
                    if (num > 0)
                    {
                        return 0;//删除成功
                    }
                    else
                    {
                        return 1;//删除失败
                    }
                }
                else
                {
                    return 2;//已删除
                }
            }
        }
        #endregion

        public TakeMoneyDTO ToDTO(TakeMoneyEntity takemoney)
        {
            TakeMoneyDTO takeDTO = new TakeMoneyDTO();
            takeDTO.ID = takemoney.ID;
            takeDTO.UserID = takemoney.UserID;
            takeDTO.TakeMoney = takemoney.TakeMoney;
            takeDTO.TakePoundage = takemoney.TakePoundage;
            takeDTO.RealityMoney = takemoney.RealityMoney;
            takeDTO.Flag = takemoney.Flag;
            takeDTO.BankAccount = takemoney.BankAccount;
            takeDTO.BankName = takemoney.BankName;
            takeDTO.BankAccountUser = takemoney.BankAccountUser;
            takeDTO.BankDian = takemoney.BankDian;
            takeDTO.TakeTime = takemoney.TakeTime;
            takeDTO.Take001 = takemoney.Take001;
            takeDTO.Take002 = takemoney.Take002;
            takeDTO.Take003 = takemoney.Take003;
            takeDTO.Take004 = takemoney.Take004;
            takeDTO.Take005 = takemoney.Take005;
            takeDTO.Take006 = takemoney.Take006;
            takeDTO.UserCode = takemoney.Users.UserCode;
            takeDTO.TrueName = takemoney.Users.TrueName;
            takeDTO.StateName = takemoney.Flag == 0 ? "等待审核" : "已确认";

            return takeDTO;
        }
    }
}
