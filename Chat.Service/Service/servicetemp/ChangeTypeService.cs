using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
    public class ChangeTypeService : IChangeTypeService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<ChangeTypeDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<ChangeTypeEntity> change = new CommonService<ChangeTypeEntity>(dbcontext);
                return change.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }

        public ChangeTypeDTO ToDTO(ChangeTypeEntity entity)
        {
            ChangeTypeDTO dto = new ChangeTypeDTO();
            dto.ID = entity.ID;
            dto.TypeName = entity.TypeName;
            dto.TypeNameEn = entity.TypeNameEn;
            return dto;
        }

    }
}
