using System;
using SDMS.DTO.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IMemberService : IServiceSupport
    {
        MemberSearchResult GetPageList(int pageIndex, int pageSize);
        LevelDTO[] GetAll(); 
        int Del(long id);
        int Open(long id);
        int Close(long id);
        int Pass(long id);
        /// <summary>
        /// 用ID 查询这个账户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MemberSearchResult ToUser(int id);
        /// <summary>
        /// 修改等级
        /// </summary>
        /// <param name="GetLoginID"></param>
        /// <param name="LeveID"></param>
        /// <returns></returns>
        long Update_LeveID(int GetLoginID, int LeveID);
        /// <summary>
        /// 修改升级,扣款，加人流水表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        long Update_LeveID(int GetLoginID, int LeveID, decimal Amount);
        /// <summary>
        /// 后台用
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="usercode"></param>
        /// <param name="Level"></param>
        /// <param name="Strat"></param>
        /// <param name="End"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        MemberSearchResult GetMemberList(string Id, string usercode,string Level, DateTime? Strat, DateTime? End ,int PageIndex, int PageSize,int i);
        /// <summary>
        /// 前台查询未开通会员
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="GetLoginID">GetLoginID 推荐会员</param>
        /// <param name="usercode"></param>
        /// <param name="Level"></param>
        /// <param name="Strat"></param>
        /// <param name="End"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="i">i=0就是查询未开通会员 2 是开通会员   3是注册会员</param>
        /// <returns></returns>
        MemberSearchResult GetMemberList(string Id, int GetLoginID, string usercode, string Level, DateTime? Strat, DateTime? End, int PageIndex, int PageSize, int i);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        int Update_Date(MemberListDTO MemberList);
    }

    public class MemberSearchResult
    {
        public MemberListDTO[] MemberList { get; set; }
        public long TotalCount { get; set; }
    }
}
