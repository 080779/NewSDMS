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
        long AddNew(string name, string mobile, string description, string password, long?[] roleIds);
        bool CheckUserName(string userName);
        bool Update(long Id, string name, string mobile,string description, string password, long?[] roleIds);
        AdminEditDTO GetById(long Id);
        AdminDTO GetByAdminId(long Id);
        long GetIdByName(string userName);
        AdminSearchResult GetPageList(int pageIndex, int pageSize);
        bool Delete(long Id);
        bool HasPermission(long adminUserId, string permissionName);
        long CheckLogin(string name, string password);
        string GetNameById(long id);
    }


    public class AdminSearchResult
    {
        public AdminDTO[] AdminList { get; set; }
        public long TotalCount { get; set; }
    }
}
