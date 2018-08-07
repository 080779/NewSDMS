using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class ShareBonusService : IShareBonusService
    {
        public bool Average(decimal Amount)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<HolderEntity> cs = new CommonService<HolderEntity>(dbc);
                CommonService<JournalTypeEntity> jcs = new CommonService<JournalTypeEntity>(dbc);
                long average = jcs.GetAll().SingleOrDefault(j => j.Name == "average").Id;
                var holders = cs.GetAll();
                if (holders.LongCount() <= 0)
                {
                    return false;
                }
                //foreach (var holder in holders)
                //{
                //    holder.TotalBonus = holder.TotalBonus + Amount * holder.Proportion;
                //    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                //    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;
                //    holder.Point = true;

                //    JournalEntity journal = new JournalEntity();
                //    journal.HolderId = holder.Id;
                //    journal.BalanceAmount = holder.TotalAssets;
                //    journal.InAmount = Amount * holder.Proportion;
                //    journal.JournalTypeId = average;
                //    journal.Remark = "获得平均分红";
                //    dbc.Journal.Add(journal);
                //}
                holders.ForEachAsync(holder =>
                {
                    holder.TotalBonus = holder.TotalBonus + Amount * holder.Proportion;
                    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;
                    holder.Point = true;

                    JournalEntity journal = new JournalEntity();
                    journal.HolderId = holder.Id;
                    journal.BalanceAmount = holder.TotalAssets;
                    journal.InAmount = Amount * holder.Proportion;
                    journal.JournalTypeId = average;
                    journal.Remark = "获得平均分红";
                    dbc.Journal.Add(journal);
                });                
                dbc.SaveChanges();
                return true;
            }
        }
        public bool Directional()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                CommonService<JournalTypeEntity> jcs = new CommonService<JournalTypeEntity>(dbc);
                CommonService<HolderEntity> hcs = new CommonService<HolderEntity>(dbc);
                var set = cs.GetAll().SingleOrDefault(s => s.Name=="setup");
                long directional = jcs.GetAll().SingleOrDefault(j => j.Name == "directional").Id; 
                var holders = hcs.GetAll();
                if(set==null)
                {
                    return false;
                }
                if(holders.LongCount()<=0)
                {
                    return false;
                }
                decimal rate=set.Rate;
                if(set.ChangeTime.AddDays(1).Date>=DateTime.Now.Date)
                {
                    rate = set.OldRate;
                }
                DateTime time = DateTime.Now.Date.AddSeconds(-1);
                foreach (var holder in holders)
                {
                    holder.TotalBonus = holder.TotalBonus + holder.Amount*rate;
                    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;
                    holder.Point = true;

                    JournalEntity journal = new JournalEntity();
                    journal.CreateTime = time;
                    journal.HolderId = holder.Id;
                    journal.BalanceAmount = holder.TotalAssets;
                    journal.InAmount = holder.Amount * rate;
                    journal.JournalTypeId = directional;
                    journal.Remark = "获得定向分红";
                    dbc.Journal.Add(journal);
                }
                dbc.SaveChanges();
                return true;
            }            
        }
        public long ProcDirectional()
        {
            using (MyDbContext dbc = new MyDbContext())
            {                
                return dbc.Database.ExecuteSqlCommand("exec sharebonus");
            }
        }
    }
}
