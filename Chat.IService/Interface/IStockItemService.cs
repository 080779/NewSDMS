using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IStockItemService:IServiceSupport
    {
        StockItemDTO GetById(long id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name">股票项目名</param>
        /// <param name="description">股票项目描述</param>
        /// <param name="totalAmount">总金额</param>
        /// <param name="totalCopies">总份数</param>
        /// <param name="issueCopies">发行份数</param>
        /// <returns></returns>
        long AddNew(string name,string description,decimal totalAmount,long totalCopies,long issueCopies);
        bool Update(long id,string name, string description, decimal totalAmount, long totalCopies, long issueCopies);
        bool Delete(long id);
    }
}
