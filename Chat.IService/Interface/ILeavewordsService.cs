using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface ILeavewordsService : IServiceSupport
    {
        /// <summary>
        /// 发件箱分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        LeaveOutPageResult GetPageList(long UserID, int FromUserType, int PageIndex, int PageSize);
        /// <summary>
        /// 收件箱分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        LeaveMsgPageResult GetLeaveMsgPageList(long ToUserID, int ToUserType, int PageIndex, int PageSize);
        /// <summary>
        /// 添加留言记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>

        long Add(long UserID, string Title, string Context);
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        List<LeaveMsgDTO> GetList();
        
        /// <summary>
        ///  后台回复留言
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        long ContentAdd(long Id, string Context);
        // <summary>
        ///  前台回复留言
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        long LeaveReMsgAdd(long Id, long userid, string UserCode, string Context);
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        LeaveMsgDTO GetModelByID(long ID);
        /// <summary>
        /// 获取回复内容列表
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        List<LeaveReMsgDTO> GetLeaveReMsgList();
        /// <summary>
        /// 获取回复内容列表
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Context"></param>
        /// <returns></returns>
        LeaveReMsgPageResult GetLeaveReMsgPageList(long Id, int PageIndex, int PageSize);
    }

    public class LeaveOutPageResult
    {
        public long TotalCount { get; set; }
        public LeaveMsgDTO[] LeaveOuts { get; set; }
    }
    public class LeaveMsgPageResult
    {
        public long TotalCount { get; set; }
        public LeaveMsgDTO[] LeaveMsg { get; set; }
    }
    public class LeaveReMsgPageResult
    {
        public long TotalCount { get; set; }
        public LeaveReMsgDTO[] Leaveremsgs { get; set; }
    }
}
