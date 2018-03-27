using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
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
                var holders = cs.GetAll();
                if(holders==null)
                {
                    return false;
                }
                foreach (var holder in holders)
                {
                    holder.TotalBonus = holder.TotalBonus + Amount * holder.Proportion;
                    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;

                    JournalEntity journal = new JournalEntity();
                    journal.HolderId = holder.Id;
                    journal.BalanceAmount = holder.TotalAssets;
                    journal.InAmount = Amount * holder.Proportion;
                    journal.JournalTypeId = 7;
                    journal.Remark = "获得平均分红";
                    dbc.Journal.Add(journal);
                }
                dbc.SaveChanges();
                return true;
            }
        }
        public bool Directional(long setId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                CommonService<HolderEntity> hcs = new CommonService<HolderEntity>(dbc);
                var set = cs.GetAll().SingleOrDefault(s => s.Id == setId);
                var holders = hcs.GetAll();
                if(set==null)
                {
                    return false;
                }
                if(holders==null)
                {
                    return false;
                }
                decimal rate=set.Rate;
                if(set.ChangeTime.AddDays(1).Date>=DateTime.Now.Date)
                {
                    rate = set.OldRate;
                }
                foreach(var holder in holders)
                {
                    holder.TotalBonus = holder.TotalBonus + holder.Amount*rate;
                    holder.TotalAssets = holder.Amount + holder.TotalBonus - holder.HaveBonus;
                    holder.TakeBonus = holder.TotalBonus - holder.HaveBonus;

                    JournalEntity journal = new JournalEntity();
                    journal.HolderId = holder.Id;
                    journal.BalanceAmount = holder.TotalAssets;
                    journal.InAmount = holder.Amount * rate;
                    journal.JournalTypeId = 5;
                    journal.Remark = "获得定向分红";
                    dbc.Journal.Add(journal);
                }
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
