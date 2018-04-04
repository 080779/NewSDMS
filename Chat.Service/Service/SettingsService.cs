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
    public class SettingsService : ISettingsService
    {
        public SettingsDTO[] GetAll()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SettingsEntity> cs = new CommonService<SettingsEntity>(dbc);
                var settings=cs.GetAll();
                return settings.Select(s => new SettingsDTO { CreateTime = s.CreateTime, Description = s.Description, Id = s.Id, Name = s.Name, Value = s.Value }).ToArray();;
            }
        }
        public SettingsDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SettingsEntity> cs = new CommonService<SettingsEntity>(dbc);
                var setting = cs.GetAll().SingleOrDefault(s => s.Id == id);
                if(setting==null)
                {
                    return null;
                }
                return new SettingsDTO { CreateTime = setting.CreateTime, Description = setting.Description, Id = setting.Id, Name = setting.Name, Value = setting.Value };
            }
        }
        public long AddNew(string key, string value, string description)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                SettingsEntity entity = new SettingsEntity();
                entity.Name = key;
                entity.Value = value;
                entity.Description = description;
                dbc.Settings.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        public bool Update(long id, string value)
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
                dbc.SaveChanges();
                return true;
            }
        }

        public string GetValueByKey(string key)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SettingsEntity> cs = new CommonService<SettingsEntity>(dbc);
                var setting = cs.GetAll().SingleOrDefault(s => s.Name == key);
                if (setting==null)
                {
                    return null;
                }
                return setting.Value;
            }
        }
        public SettingsDTO[] GetByName(string name)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<SettingsEntity> cs = new CommonService<SettingsEntity>(dbc);
                var settings = cs.GetAll().Where(s => s.Name.Contains(name));
                if(settings.LongCount()<=0)
                {
                    return null;
                }
                return settings.Select(s => new SettingsDTO { CreateTime = s.CreateTime, Description = s.Description, Id = s.Id, Name = s.Name, Value = s.Value }).ToArray();
            }
        }
    }
}
