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
    public class CurrencyNameService : ICurrencyNameService
    {
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<CurrencyNameDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<CurrencyNameEntity> csr = new CommonService<CurrencyNameEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion

        public CurrencyNameDTO ToDTO(CurrencyNameEntity currency)
        {
            CurrencyNameDTO c = new CurrencyNameDTO();
            c.ID = currency.ID;
            c.CurrencyName = currency.CurrencyName;
            c.CurrencyNameEn = currency.CurrencyNameEn;
            return c;
        }
    }
}
