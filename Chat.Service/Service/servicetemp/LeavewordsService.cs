using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Service
{
    public class LeavewordsService : ILeavewordsService
    {
        /*
        #region 添加留言记录
        /// <summary>
        /// 添加留言记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>
     
        /// <returns></returns>
        public long Add(long UserID, string Title, string Context)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                LeaveMsgEntity leavwordsModel = new LeaveMsgEntity();
                CommonService<UserEntity> user = new CommonService<UserEntity>(dbcontext);
                UserEntity uentity = user.GetById(UserID);
                leavwordsModel.UserID = UserID;
                leavwordsModel.MsgTitle = Title;
                leavwordsModel.MsgContent = Context;
                leavwordsModel.LeaveTime = DateTime.Now;
                leavwordsModel.IsRead = 0;
                leavwordsModel.IsReply = 0;
                leavwordsModel.FromUserType = 1;
                leavwordsModel.UserCode = uentity.UserCode;
                leavwordsModel.FromIDIsDel = 0;
                leavwordsModel.ToIDIsDel = 0;
                leavwordsModel.ToUserType = 2;
                leavwordsModel.ToUserID = 1;
                leavwordsModel.ToUserCode = "admin";
                dbcontext.LeaveMsg.Add(leavwordsModel);
                dbcontext.SaveChanges();
                return leavwordsModel.ID;
            }
           
        }
        #endregion
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<LeaveMsgDTO> GetList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<LeaveMsgEntity> csr = new CommonService<LeaveMsgEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => ToDTO(p)).ToList();
            }
        }
        #endregion
        // 发件箱列表分页
        /// <summary>
        ///  发件箱列表分页
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

        public LeaveOutPageResult GetPageList(long UserID, int FromUserType, int PageIndex, int PageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<LeaveMsgEntity> cs = new CommonService<LeaveMsgEntity>(dbc);
                var Leave = cs.GetAll();
                LeaveOutPageResult LeaveOut = new LeaveOutPageResult();
              
                if (UserID > 0)
                {
                    Leave = Leave.Where(p => p.UserID == UserID);
                }
                if (FromUserType > 0)
                {
                    Leave = Leave.Where(p => p.FromUserType == FromUserType);
                }

                LeaveOut.TotalCount = Leave.LongCount();
                LeaveOut.LeaveOuts = Leave.OrderByDescending(p => p.ID).ToList().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return LeaveOut;
            }
        }

        // 收件箱列表分页
        /// <summary>
        ///  收件箱列表分页
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="GetLoginID">GetLoginID 推荐会员</param>
        /// <param name="usercode"></param>
        /// <param name="Level"></param>
        /// <param name="Strat"></param>
        /// <param name="End"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
      
        /// <returns></returns>

        public LeaveMsgPageResult GetLeaveMsgPageList(long ToUserID, int ToUserType, int PageIndex, int PageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<LeaveMsgEntity> cs = new CommonService<LeaveMsgEntity>(dbc);
                var Leave = cs.GetAll();
                LeaveMsgPageResult LeaveMsg = new LeaveMsgPageResult();

                if (ToUserID > 0)
                {
                    Leave = Leave.Where(p => p.ToUserID == ToUserID);
                }
                if (ToUserType > 0)
                {
                    Leave = Leave.Where(p => p.ToUserType == ToUserType);
                }

                LeaveMsg.TotalCount = Leave.LongCount();
                LeaveMsg.LeaveMsg = Leave.OrderByDescending(p => p.ID).ToList().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return LeaveMsg;
            }
        }

        public IUserService userService { get; set; }
        public LeaveMsgDTO ToDTO(LeaveMsgEntity msg)
        {
            LeaveMsgDTO LeaveMsg = new LeaveMsgDTO();
            LeaveMsg.ID = msg.ID;
            LeaveMsg.MsgTitle = msg.MsgTitle;
            LeaveMsg.MsgContent = msg.MsgContent;
            LeaveMsg.LeaveTime = msg.LeaveTime;
            LeaveMsg.IsRead = msg.IsRead;
            LeaveMsg.IsReply = msg.IsReply;
            LeaveMsg.IsReplyName = msg.IsReply == 0 ? "未回复" : "已回复";
            LeaveMsg.FromUserType = msg.FromUserType;
            LeaveMsg.UserID = Convert.ToInt64(msg.UserID);
            LeaveMsg.FromIDIsDel = Convert.ToInt32(msg.FromIDIsDel);
            LeaveMsg.UserCode = msg.UserCode;
            LeaveMsg.ToUserType = msg.ToUserType;
            LeaveMsg.ToUserID = Convert.ToInt32(msg.ToUserID);
            LeaveMsg.ToUserCode = msg.ToUserCode;
            LeaveMsg.ToIDIsDel = Convert.ToInt32(msg.ToIDIsDel);
            LeaveMsg.IsDeleted = msg.IsDeleted;
            LeaveMsg.CreateTime = msg.CreateTime;
            //LeaveMsg.LeaveOutName = userService.GetUserCodeForMessage(LeaveMsg.ToUserID, LeaveMsg.ToUserType);
            //LeaveMsg.LeaveInName = userService.GetUserCodeForMessage(LeaveMsg.UserID, LeaveMsg.FromUserType);
            return LeaveMsg;
        }
        #region 根据ID查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public LeaveMsgDTO GetModelByID(long ID)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<LeaveMsgEntity> csr = new CommonService<LeaveMsgEntity>(dbcontext);
                LeaveMsgEntity take = csr.GetById(ID);
                LeaveMsgDTO model = null;
                if (take != null)
                {
                    model = ToDTO(take);
                }
                return model;
            }
        }
        #endregion

        #region 后台回复留言记录
        /// <summary>
        /// 后台回复留言记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>

        /// <returns></returns>
        public long ContentAdd(long Id, string Context)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                LeaveReMsgEntity leaveReMsgModel = new LeaveReMsgEntity();
                AdminEntity admin = new AdminEntity();
                leaveReMsgModel.LeaveID = Id;
                leaveReMsgModel.UserType = 2;
                leaveReMsgModel.UserID = admin.ID;
                leaveReMsgModel.UserCode = admin.UserName;
                leaveReMsgModel.ReContent = Context;
                leaveReMsgModel.ReTime = DateTime.Now;
                dbcontext.LeaveReMsg.Add(leaveReMsgModel);
                dbcontext.SaveChanges();
                return leaveReMsgModel.ID;
            }

        }
        #endregion
        #region 前台回复留言记录
        /// <summary>
        /// 前台回复留言记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>

        /// <returns></returns>
        public long LeaveReMsgAdd(long Id,long userid,string UserCode, string Context)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                LeaveReMsgEntity leaveReMsgModel = new LeaveReMsgEntity();
    
                leaveReMsgModel.LeaveID = Id;
                leaveReMsgModel.UserType = 2;
                leaveReMsgModel.UserID = userid;
                leaveReMsgModel.UserCode = UserCode;
                leaveReMsgModel.ReContent = Context;
                leaveReMsgModel.ReTime = DateTime.Now;
                dbcontext.LeaveReMsg.Add(leaveReMsgModel);
                dbcontext.SaveChanges();
                return leaveReMsgModel.ID;
            }

        }
        #endregion
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<LeaveReMsgDTO> GetLeaveReMsgList()
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<LeaveReMsgEntity> csr = new CommonService<LeaveReMsgEntity>(dbcontext);
                return csr.GetAll().ToList().Select(p => RToDTO(p)).ToList();
            }
        }
        #endregion

        public LeaveReMsgPageResult GetLeaveReMsgPageList(long Id, int PageIndex, int PageSize)
        {
            using (MyDbContext dbcontext = new MyDbContext())
            {
                CommonService<LeaveReMsgEntity> csr = new CommonService<LeaveReMsgEntity>(dbcontext);
                LeaveReMsgPageResult PageResult = new LeaveReMsgPageResult();
                var LeaveOutQuery = csr.GetAll();
                LeaveOutQuery = LeaveOutQuery.Where(l => l.LeaveID==(Id));
               


                PageResult.TotalCount = LeaveOutQuery.LongCount();
                PageResult.Leaveremsgs = LeaveOutQuery.OrderByDescending(p => p.CreateTime).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => RToDTO(p)).ToArray();
                return PageResult;
            }
        }
        public LeaveReMsgDTO RToDTO(LeaveReMsgEntity msg)
        {
            LeaveReMsgDTO LeaveReMsg = new LeaveReMsgDTO();
            LeaveReMsg.ID = msg.ID;
            LeaveReMsg.ReContent = msg.ReContent;
            LeaveReMsg.ReTime = msg.ReTime;
            LeaveReMsg.UserCode = msg.UserCode;
          
            return LeaveReMsg;
        }
        */
        public long Add(long UserID, string Title, string Context)
        {
            throw new NotImplementedException();
        }

        public long ContentAdd(long Id, string Context)
        {
            throw new NotImplementedException();
        }

        public LeaveMsgPageResult GetLeaveMsgPageList(long ToUserID, int ToUserType, int PageIndex, int PageSize)
        {
            throw new NotImplementedException();
        }

        public List<LeaveReMsgDTO> GetLeaveReMsgList()
        {
            throw new NotImplementedException();
        }

        public LeaveReMsgPageResult GetLeaveReMsgPageList(long Id, int PageIndex, int PageSize)
        {
            throw new NotImplementedException();
        }

        public List<LeaveMsgDTO> GetList()
        {
            throw new NotImplementedException();
        }

        public LeaveMsgDTO GetModelByID(long ID)
        {
            throw new NotImplementedException();
        }

        public LeaveOutPageResult GetPageList(long UserID, int FromUserType, int PageIndex, int PageSize)
        {
            throw new NotImplementedException();
        }

        public long LeaveReMsgAdd(long Id, long userid, string UserCode, string Context)
        {
            throw new NotImplementedException();
        }
    }
}
