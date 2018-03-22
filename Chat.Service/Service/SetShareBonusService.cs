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
    public class SetShareBonusService : ISetShareBonusService
    {
        public SetShareBonusDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s=>s.Id==id);
                if(entity==null)
                {
                    return null;
                }
                return new SetShareBonusDTO { ChangeTime = entity.ChangeTime, CreateTime = entity.CreateTime, Id = entity.Id, OldRate = entity.OldRate, Rate = entity.Rate };
            }
        }
        public bool Update(long id, decimal rate)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s => s.Id == id);
                if(entity==null)
                {
                    return false;
                }
                entity.OldRate = entity.Rate;
                entity.Rate = rate;
                entity.ChangeTime = DateTime.Now;
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
