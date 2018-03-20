using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    /// <summary>
    /// 城市服务接口
    /// </summary>
    public interface ICityService : IServiceSupport
    {
        long AddNew(string cityId, string cityName, string cityEn, string father);
        CityDTO GetById(long id);
        CityDTO[] GetAll();
    }
}
