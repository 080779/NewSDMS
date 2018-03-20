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
    public class RemitService : IRemitService
    {
        #region 添加充值记录
        /// <summary>
        /// 添加充值记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Amount"></param>
        /// <param name="BankName"></param>
        /// <param name="BankAccount"></param>
        /// <param name="BankAccountUser"></param>
        /// <returns></returns>
        public long Add(RemitDTO dto)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                RemitEntity remitModel = new RemitEntity();
                remitModel.UserID = dto.UserID;
                remitModel.RemitMoney = dto.RemitMoney;
                remitModel.BankName = dto.BankName;
                remitModel.BankAccount = dto.BankAccount;
                remitModel.BankAccountUser = dto.BankAccountUser;
                remitModel.RechargeableDate = dto.RechargeableDate;
                remitModel.OutBankName = dto.OutBankName;
                remitModel.OutBankAccount = dto.OutBankAccount;
                remitModel.OutBankAccountUser = dto.OutBankAccountUser;
                remitModel.Remark = dto.Remark;
                remitModel.AddDate = DateTime.Now;
                remitModel.State = dto.State;
                dbcontext.Remit.Add(remitModel);
                dbcontext.SaveChanges();
                return remitModel.ID;
            }
        } 
        #endregion

        #region 更新充值记录状态
        /// <summary>
        /// 更新充值记录状态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public int UpdateState(long ID, int State)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<RemitEntity> csr = new CommonService<RemitEntity>(dbcontext);
                RemitEntity remitModel = csr.GetById(ID);
                if (remitModel == null)
                {
                    return 2;//已删除
                }
                if(remitModel.State == 1)
                {
                    return 3;//已确认
                }
                remitModel.State = State;
                remitModel.RechargeableDate = DateTime.Now;
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
        public List<RemitDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<RemitEntity> csr = new CommonService<RemitEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        } 
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public RemitPageResult GetPageList(long UserID, string UserCode, string TrueName, int State, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<RemitEntity> csr = new CommonService<RemitEntity>(dbcontext);
                RemitPageResult PageResult = new RemitPageResult();
                var RemitQuery = csr.GetAll();
                if (UserID > 0)
                {
                    RemitQuery = RemitQuery.Where(p => p.UserID == UserID);
                }
                if (!string.IsNullOrEmpty(UserCode))
                {
                    RemitQuery = RemitQuery.Where(p => p.Users.UserCode.Contains(UserCode));
                }
                if (!string.IsNullOrEmpty(TrueName))
                {
                    RemitQuery = RemitQuery.Where(p => p.Users.TrueName.Contains(TrueName));
                }
                if (State > -1)
                {
                    RemitQuery = RemitQuery.Where(p => p.State == State);
                }
                if (StartTime != null)
                {
                    RemitQuery = RemitQuery.Where(p => p.AddDate >= StartTime);
                }
                if (EndTime != null)
                {
                    RemitQuery = RemitQuery.Where(p => p.AddDate <= EndTime);
                }
                PageResult.TotalCount = RemitQuery.LongCount();
                PageResult.Remits = RemitQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
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
        public RemitDTO GetModelByID(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<RemitEntity> csr = new CommonService<RemitEntity>(dbcontext);
                RemitEntity re = csr.GetById(ID);
                RemitDTO model = null;
                if (re != null)
                {
                    model = ToDTO(re);
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
                CommonService<RemitEntity> csr = new CommonService<RemitEntity>(dbcontext);
                RemitEntity re = csr.GetById(ID);
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

        public RemitDTO ToDTO(RemitEntity remit)
        {
            RemitDTO Rdto = new RemitDTO();
            Rdto.ID = remit.ID;
            Rdto.RemitMoney = remit.RemitMoney;
            Rdto.State = remit.State;
            Rdto.UserID = remit.UserID;
            Rdto.RechargeableDate = remit.RechargeableDate;
            Rdto.BankAccount = remit.BankAccount;
            Rdto.BankName = remit.BankName;
            Rdto.BankAccountUser = remit.BankAccountUser;
            Rdto.AddDate = remit.AddDate;
            Rdto.Remark = remit.Remark;
            Rdto.OutBankAccount = remit.OutBankAccount;
            Rdto.OutBankName = remit.OutBankName;
            Rdto.OutBankAccountUser = remit.OutBankAccountUser;
            Rdto.UserCode = remit.Users.UserCode;
            Rdto.TrueName = remit.Users.TrueName;
            Rdto.StateName = remit.State == 0 ? "等待审核" : "已确认";
            return Rdto;
        }

    }
}
