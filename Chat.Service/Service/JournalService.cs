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
        public JournalPageResult GetPageList(long? holderId, string mobile, string name, long? journalTypeId, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
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

            return jourDTO;
        }
        #endregion
    }
}