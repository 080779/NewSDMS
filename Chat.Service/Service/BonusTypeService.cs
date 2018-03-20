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
    public class BonusTypeService : IBonusTypeService
    {
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<BonusTypeDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<BonusTypeEntity> csr = new CommonService<BonusTypeEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion

        public BonusTypeDTO ToDTO(BonusTypeEntity model)
        {
            BonusTypeDTO dto = new BonusTypeDTO();
            dto.ID = model.ID;
            dto.TypeID = model.TypeID;
            dto.TypeName = model.TypeName;
            dto.TypeNameEn = model.TypeNameEn;
            dto.CreateTime = model.CreateTime;
            return dto;
        }

    }
}
