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
        public PowerDTO[] GetByParentId(int Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PowerEntity> cs = new CommonService<PowerEntity>(dbc);
                return cs.GetAll().Where(p => p.ParentId == 0).ToList().Select(p => new PowerDTO { CreateTime = p.CreateTime, Id = p.Id, ParentId = p.ParentId, MenuName = p.MenuName, TypeId = p.TypeId, URL = p.URL }).ToArray();
            }
        }

        public PowerDTO[] GetByTypeId(int Id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<PowerEntity> cs = new CommonService<PowerEntity>(dbc);
                if(!cs.GetAll().Any(p=>p.ParentId==Id))
                {
                    return null;
                }
                return cs.GetAll().Where(p => p.ParentId ==Id ).ToList().Select(p => new PowerDTO { CreateTime = p.CreateTime, Id = p.Id, ParentId = p.ParentId, MenuName = p.MenuName, TypeId = p.TypeId, URL = p.URL }).ToArray();
            }
        }
    }
}
