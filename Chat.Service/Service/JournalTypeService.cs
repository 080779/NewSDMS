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
    public class JournalTypeService : IJournalTypeService
    {
        public JournalTypeDTO[] GetAll()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<JournalTypeEntity> cs = new CommonService<JournalTypeEntity>(dbc);
                return cs.GetAll().ToList().Select(j => new JournalTypeDTO { CreateTime = j.CreateTime, Description = j.Description, Id = j.Id, Name = j.Name }).ToArray();
            }               
        }
        public long AddNew(string name, string description)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                JournalTypeEntity entity = new JournalTypeEntity();
                entity.Name = name;
                entity.Description = description;
                dbc.JournalTypes.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }
                
        public bool Update(long id, string name, string description)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<JournalTypeEntity> cs = new CommonService<JournalTypeEntity>(dbc);
                var entity=cs.GetAll().SingleOrDefault(j => j.Id == id);
                if(entity==null)
                {
                    return false;
                }
                entity.Name = name;
                entity.Description = description;
                dbc.SaveChanges();
                return true;
            }
        }

        public bool Delete(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<JournalTypeEntity> cs = new CommonService<JournalTypeEntity>(dbc);
                var entity = cs.GetAll().SingleOrDefault(j => j.Id == id);
                if (entity == null)
                {
                    return false;
                }
                entity.IsDeleted = true;
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
