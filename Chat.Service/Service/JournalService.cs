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
        #region 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="holderId"></param>
        /// <param name="mobile"></param>
        /// <param name="name"></param>
        /// <param name="journalTypeId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JournalPageResult GetPageList(long? holderId, string mobile, string name,string remark, long? journalTypeId, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<JournalEntity> csr = new CommonService<JournalEntity>(dbcontext);
                JournalPageResult PageResult = new JournalPageResult();
                var JournalQuery = csr.GetAll();

                if (holderId!=null)
                {
                    JournalQuery = JournalQuery.Where(p => p.HolderId == holderId);
                }
                if (!string.IsNullOrEmpty(mobile))
                {
                    JournalQuery = JournalQuery.Where(p => p.Holder.Mobile.Contains(mobile));
                }
                if (!string.IsNullOrEmpty(name))
                {
                    JournalQuery = JournalQuery.Where(p => p.Holder.Name.Contains(name));
                }
                if(!string.IsNullOrEmpty(remark))
                {
                    JournalQuery = JournalQuery.Where(p=>p.Remark.Contains(remark));
                }
                if (journalTypeId != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.JournalTypeId == journalTypeId);
                }
                if (startTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime >= startTime);
                }
                if (endTime != null)
                {
                    JournalQuery = JournalQuery.Where(p => p.CreateTime <= endTime);
                }
                PageResult.TotalCount = JournalQuery.LongCount();
                PageResult.Journals = JournalQuery.OrderByDescending(p => p.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(p => ToDTO(p)).ToArray();                

                return PageResult;
            }
        }
        #endregion
        public decimal YesterdayBonus(long id)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<JournalEntity> cs = new CommonService<JournalEntity>(dbcontext);
                CommonService<JournalTypeEntity> jcs = new CommonService<JournalTypeEntity>(dbcontext);
                long average = jcs.GetAll().SingleOrDefault(j=>j.Name== "average").Id;
                long directional = jcs.GetAll().SingleOrDefault(j => j.Name == "directional").Id;
                DateTime time = DateTime.Now.AddDays(-1);
                var bonus = cs.GetAll().Where(j => j.HolderId == id).Where(j => j.CreateTime.Year==time.Year && j.CreateTime.Month==time.Month && j.CreateTime.Day==time.Day).Where(j=>j.JournalTypeId== average || j.JournalTypeId== directional).Sum(j=>j.InAmount);
                if(bonus==null)
                {
                    return 0;
                }
                return (decimal)bonus;
            }
        }
        /// <summary>
        /// 获得流水列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="journalType">提现、分红</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JournalDTO[] GetBonusList(long id,string journalType, int pageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<JournalEntity> cs = new CommonService<JournalEntity>(dbcontext);
                CommonService<JournalTypeEntity> jcs = new CommonService<JournalTypeEntity>(dbcontext);
                var bonus = cs.GetAll().Where(j => j.HolderId == id);
                if(journalType=="分红")
                {
                    long journalTypeId = jcs.GetAll().SingleOrDefault(j => j.Name == "directional").Id;
                    long journalTypeId01 = jcs.GetAll().SingleOrDefault(j => j.Name == "average").Id;
                    bonus = bonus.Where(j => j.JournalTypeId == journalTypeId || j.JournalTypeId == journalTypeId01);
                }
                else
                {
                    long journalTypeId = jcs.GetAll().SingleOrDefault(j => j.Name == "takecash").Id;
                    bonus = bonus.Where(j => j.JournalTypeId == journalTypeId);
                }
                
                if (bonus.Count()<=0)
                {
                    return null;
                }
                return bonus.OrderByDescending(j => j.CreateTime).Take(pageSize).ToList().Select(j => ToDTO(j)).ToArray();
            }
        }
        #region ToDTO
        public JournalDTO ToDTO(JournalEntity journal)
        {
            JournalDTO jourDTO = new JournalDTO();
            jourDTO.Id = journal.Id;
            jourDTO.CreateTime = journal.CreateTime;
            jourDTO.HolderId = journal.HolderId;
            jourDTO.HolderName = journal.Holder.Name;
            jourDTO.JournalTypeId = journal.JournalTypeId;
            jourDTO.JournalTypeName = journal.JournalType.Name;
            jourDTO.Remark = journal.Remark;
            jourDTO.InAmount = journal.InAmount;
            jourDTO.OutAmount = journal.OutAmount;
            jourDTO.BalanceAmount = journal.BalanceAmount;
            jourDTO.JournalTypeDescription = journal.JournalType.Description;

            return jourDTO;
        }                
        #endregion
    }
}