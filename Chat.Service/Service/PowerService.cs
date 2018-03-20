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
    public class PowerService : IPowerService
    {
        public PowerDTO[] GetByParentID(int id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PowerEntity> cs = new CommonService<PowerEntity>(dbc);
                return cs.GetAll().Where(p => p.ParentID == 0).ToList().Select(p => new PowerDTO { CreateTime = p.CreateTime, ID = p.ID, ParentID = p.ParentID, MenuName = p.MenuName, TypeID = p.TypeID, URL = p.URL }).ToArray();
            }
        }

        public PowerDTO[] GetByTypeId(int id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PowerEntity> cs = new CommonService<PowerEntity>(dbc);
                if(!cs.GetAll().Any(p=>p.ParentID==id))
                {
                    return null;
                }
                return cs.GetAll().Where(p => p.ParentID ==id ).ToList().Select(p => new PowerDTO { CreateTime = p.CreateTime, ID = p.ID, ParentID = p.ParentID, MenuName = p.MenuName, TypeID = p.TypeID, URL = p.URL }).ToArray();
            }
        }
    }
}
