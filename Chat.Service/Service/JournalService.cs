using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class JournalService : IJournalService
    {
        #region 添加账户明细记录
        /// <summary>
        /// 添加账户明细记录
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Amount"></param>
        /// <param name="JournalType"></param>
        /// <param name="iStyle">1：增加，2：减少</param>
        /// <returns></returns>
        public long Add(long UserId, decimal InAmount, decimal OutAmount, decimal Balance, int JournalType, string Remark, string RemarkEn)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                JournalEntity jModel = new JournalEntity();
                //jModel.UserId = UserId;
                //jModel.JournalType = JournalType;
                jModel.InAmount = InAmount;
                jModel.OutAmount = OutAmount;
                jModel.BalanceAmount = Balance;
                jModel.Remark = Remark;
                dbcontext.Journal.Add(jModel);
                dbcontext.SaveChanges();
                return jModel.Id;
            }
        }
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<JournalDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<JournalEntity> csr = new CommonService<JournalEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion

        #region 分页查询
        
        public JournalPageResult GetPageList(long UserId, string UserCode, string TrueName, int JournalType, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<JournalEntity> csr = new CommonService<JournalEntity>(dbcontext);
                JournalPageResult PageResult = new JournalPageResult();
                var JournalQuery = csr.GetAll();

                //if (UserId > 0)
                //{
                //    JournalQuery = JournalQuery.Where(p => p.UserId == UserId);
                //}
                if (!string.IsNullOrEmpty(UserCode))
                {
                    //JournalQuery = JournalQuery.Where(p => p.Users.UserCode.Contains(UserCode));
                }
                if (!string.IsNullOrEmpty(TrueName))
                {
                    //JournalQuery = JournalQuery.Where(p => p.Users.TrueName.Contains(TrueName));
                }
                //if (JournalType > 0)
                //{
                //    JournalQuery = JournalQuery.Where(p => p.JournalType == JournalType);
                //}
                if (StartTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime >= StartTime);
                }
                if (EndTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime <= EndTime);
                }
                PageResult.Journals = JournalQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                PageResult.TotalCount = JournalQuery.LongCount();

                return PageResult;
            }
        }
        #endregion

        public List<JournalDTO> GetPageListTest(long UserId, string UserCode, string TrueName, int JournalType, DateTime? StartTime, DateTime? EndTime, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<JournalEntity> csr = new CommonService<JournalEntity>(dbcontext);
                
                var JournalQuery = csr.GetAll();

                //if (UserId > 0)
                //{
                //    JournalQuery = JournalQuery.Where(p => p.UserId == UserId);
                //}
                if (!string.IsNullOrEmpty(UserCode))
                {
                    //JournalQuery = JournalQuery.Where(p => p.Users.UserCode.Contains(UserCode));
                }
                if (!string.IsNullOrEmpty(TrueName))
                {
                    //JournalQuery = JournalQuery.Where(p => p.Users.TrueName.Contains(TrueName));
                }
                if (JournalType > 0)
                {
                    //JournalQuery = JournalQuery.Where(p => p.JournalType == JournalType);
                }
                if (StartTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime >= StartTime);
                }
                if (EndTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime <= EndTime);
                }
                List<JournalDTO> lj = JournalQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToList();
                
                return lj;
            }
        }

        public JournalDTO ToDTO(JournalEntity journal)
        {
            JournalDTO jourDTO = new JournalDTO();
            jourDTO.Id = journal.Id;
            //jourDTO.UserId = journal.UserId;
            //jourDTO.JournalType = journal.JournalType;
            jourDTO.InAmount = journal.InAmount;
            jourDTO.OutAmount = journal.OutAmount;
            jourDTO.BalanceAmount = journal.BalanceAmount;

            return jourDTO;
        }

    }
}