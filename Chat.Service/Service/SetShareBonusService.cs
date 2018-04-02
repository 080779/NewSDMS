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
        public bool GetSetPattern()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s => s.Name == "setup");
                if (entity == null)
                {
                    new Exception("分红设置不存在");
                }
                return entity.Flag;
            }
        }
        public SetShareBonusDTO GetSet()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s=>s.Name=="setup");
                if(entity==null)
                {
                    return null;
                }
                return new SetShareBonusDTO { ChangeTime = entity.ChangeTime, CreateTime = entity.CreateTime, Id = entity.Id, OldRate = entity.OldRate, Rate = entity.Rate ,Flag=entity.Flag };
            }
        }
        public bool Update(decimal rate)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s => s.Name == "setup");//SetShareBonus表Name默认配置为setup
                if (entity==null)
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
        /// <summary>
        /// 设置分红模式
        /// </summary>
        /// <param name="flag">true为定向，false为平均</param>
        /// <returns></returns>
        public bool Update(bool flag)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SetShareBonusEntity> cs = new CommonService<SetShareBonusEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(s => s.Name == "setup");//SetShareBonus表Name默认配置为setup
                if (entity == null)
                {
                    return false;
                }
                entity.Flag = flag;
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
