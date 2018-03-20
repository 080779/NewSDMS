using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IAdminService:IServiceSupport
    {
        long AddNew(string userName, string pwd, string spwd, string tpwd, long?[] roleIds);
        bool CheckUserName(string userName);
        bool Update(long id, string userName, string pwd, string spwd, string tpwd, long?[] roleIds);
        AdminEditDTO GetById(long id);
        AdminDTO GetByAdminId(long id);
        long GetIdByName(string userName);
        AdminSearchResult GetPageList(int pageIndex, int pageSize);
        bool Delete(long id);
        bool HasPermission(long adminUserId, string permissionName);
        long CheckLogin(string usercode, string password);
    }


    public class AdminSearchResult
    {
        public AdminListDTO[] AdminList { get; set; }
        public long TotalCount { get; set; }
    }
}
