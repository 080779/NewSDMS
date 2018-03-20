using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface ILoginService : IServiceSupport
    {
        int CheckLogin(string usercode, string password);
    }
}
