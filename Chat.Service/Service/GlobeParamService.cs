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
    public class GlobeParamService : IGlobeParamService
    {
        public GlobeParamDTO[] GetAll()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GlobeParamEntity> cs = new CommonService<GlobeParamEntity>(dbc);
                return cs.GetAll().Where(g => g.ParamAmount > 0 && g.ParamInt != 0).OrderBy(g => g.ParamInt).ToList().Select(g => ToDTO(g)).ToArray();
            }
        } 

        public bool Update(long? id,string paramVarchar)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GlobeParamEntity> cs = new CommonService<GlobeParamEntity>(dbc);
                var param = cs.GetAll().SingleOrDefault(p=>p.ID==id);
                if(param==null)
                {
                    return false;
                }
                param.ParamVarchar = paramVarchar;
                dbc.SaveChanges();
                return true;
            }
        }

        public GlobeParamDTO GetById(long? id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GlobeParamEntity> cs = new CommonService<GlobeParamEntity>(dbc);
                var param = cs.GetAll().SingleOrDefault(p => p.ID == id);
                if (param == null)
                {
                    return null;
                }
                return ToDTO(param);                
            }
        }

        public GlobeParamDTO GetByName(string name)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<GlobeParamEntity> cs = new CommonService<GlobeParamEntity>(dbc);
                var paramlist = cs.GetAll().Where(p => p.ParamName == name);
                if (paramlist.Count()<=0)
                {
                    return null;
                }
                GlobeParamEntity param = paramlist.First();
                return ToDTO(param);
            }
        }

        public GlobeParamDTO ToDTO(GlobeParamEntity entity)
        {
            GlobeParamDTO dto = new GlobeParamDTO();
            dto.EndRemark = entity.EndRemark;
            dto.ID = entity.ID;
            dto.IsEdit = entity.IsEdit;
            dto.ParamAmount = entity.ParamAmount;
            dto.ParamInt = entity.ParamInt;
            dto.ParamName = entity.ParamName;
            dto.ParamType = entity.ParamType;
            dto.ParamVarchar = entity.ParamVarchar;
            dto.Remark = entity.Remark;
            return dto;
        }
    }
}
