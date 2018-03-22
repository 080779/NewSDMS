using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class SettingsService : ISettingsService
    {
        public long AddNew(string key, string value, string description)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                SettingsEntity entity = new SettingsEntity();
                entity.Key = key;
                entity.Value = value;
                entity.Description = description;
                dbc.Settings.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        public bool Update(long id, string value, string description)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SettingsEntity> cs = new CommonService<SettingsEntity>(dbc);
                var setting = cs.GetAll().SingleOrDefault(s => s.Id == id);
                if(setting==null)
                {
                    return false;
                }
                setting.Value = value;
                setting.Description = description;
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
