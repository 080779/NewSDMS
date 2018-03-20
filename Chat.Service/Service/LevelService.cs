using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.Service.Entities;
namespace SDMS.Service.Service
{ 
    public class LevelService : ILevelService
    {
        public LevelDTO[] GetAll()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<LevelEntity> cs = new CommonService<LevelEntity>(dbc);
                return cs.GetAll().OrderByDescending(r => r.CreateTime).ToList().Select(r => new LevelDTO { LevelID = r.LevelID, LevelName = r.LevelName }).ToArray();
            }
        }
        public LevelDTO GetLevelName(int LevelID)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<LevelEntity> cs = new CommonService<LevelEntity>(dbc);
                LevelEntity model= cs.GetAll().Where(r => r.LevelID== LevelID).SingleOrDefault();
                if (model != null)
                {
                    return new LevelDTO
                    {
                        LevelID = model.LevelID,
                        LevelName = model.LevelName
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
