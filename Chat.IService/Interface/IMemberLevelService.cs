using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;

namespace SDMS.IService.Interface
{
   public interface IMemberLevelService:IServiceSupport
    {
        Member_LevelDTO Member_Leve();
        UserProSearchResult GetUserPro(int id);
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="UserPro"></param>
        /// <returns></returns>
        long Add(UserProDTO UserPro);
        List<UserProDTO> GetUerProList(int pageIndex, int pageSize);
        List<UserProDTO> GetUerProCount();
    }
    public class Member_LevelResult
    {
        public Member_LevelDTO[] Member_Level { get; set; }
        //public long TotalCount { get; set; }
    }
    public class UserProSearchResult
    {
        public UserProDTO[] UserPro { get; set; }
        //public long TotalCount { get; set; }
    }
   
}
