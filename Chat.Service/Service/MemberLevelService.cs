using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.DTO.DTO;
using SDMS.Service.Entities;

namespace SDMS.Service.Service
{
  public  class MemberLevelService: IMemberLevelService
    {

       /// <summary>
       /// 查询level等级 名称
       /// </summary>
       /// <returns></returns>
        public Member_LevelResult Member_Leve()
        {  
            using (MyDbContext dbc = new MyDbContext())
            {
                Member_LevelResult result = new Member_LevelResult();
                CommonService<LevelEntity> cs = new CommonService<LevelEntity>(dbc);
                var User = cs.GetAll(); 
                result.Member_Level = User.OrderByDescending(a=>a.ID).ToList().Select(a => new Member_LevelDTO { LevelID = a.LevelID,LevelName=a.LevelName,RegMoney=a.RegMoney }).ToArray(); 
                return result;
            }
        }
        /// <summary>
        /// 查询升级记录
        /// </summary>
        /// <returns></returns>
        public UserProSearchResult GetUserPro(int id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                UserProSearchResult result = new UserProSearchResult();
                CommonService<UserProEntity> cs = new CommonService<UserProEntity>(dbc);
                var User = cs.GetAll();
                result.UserPro = User.OrderByDescending(a => a.ID).ToList().Where(a => a.UserID== id).Select(a => ToDTO(a)).ToArray(); 
                return result;
            }
        }
        public UserProDTO ToDTO(UserProEntity User)
        {
            MemberService Member = new MemberService();
            LevelService Level= new   LevelService();
            UserProDTO UserPro = new UserProDTO();
            UserPro.ID = User.ID;
            UserPro.UserID = User.UserID;
            UserPro.LastLevel = User.LastLevel;
            UserPro.EndLevel = User.EndLevel;
            UserPro.ProMoney = User.ProMoney;
            UserPro.FlagDate = User.FlagDate;
            UserPro.Remark = User.Remark;
            UserPro.CreateTime= User.CreateTime;
            UserPro.Flag = User.Flag;
            UserPro.Pro001 = User.Pro001;
            UserPro.UserCode = "";
            UserPro.TrueName= "";
            UserPro.EndLevelName = "";
            UserPro.LastLevelName = "";
            if (Member.ToUser(int.Parse(User.UserID.ToString())).MemberList!=null)
            {
                UserPro.UserCode = Member.ToUser(int.Parse(User.UserID.ToString())).MemberList.First().UserCode;
                UserPro.TrueName = Member.ToUser(int.Parse(User.UserID.ToString())).MemberList.First().TrueName;
            }
            if (Level.GetLevelName(UserPro.LastLevel) != null)
            {
                UserPro.LastLevelName = Level.GetLevelName(UserPro.LastLevel).LevelName; 
            }
            if (Level.GetLevelName(UserPro.EndLevel) != null)
            {
                UserPro.EndLevelName = Level.GetLevelName(UserPro.EndLevel).LevelName;
            }
            return UserPro; 
       
    }
        /// <summary>
        /// 添加升级记录数据
        /// </summary>
        /// <param name="UserPro"></param>
        /// <returns></returns>
        public long Add(UserProDTO UserPro)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                UserProEntity user = new UserProEntity();
                user.AddDate = (DateTime)UserPro.AddDate;
                user.CreateTime = UserPro.CreateTime;
                user.Flag = UserPro.Flag;
                user.FlagDate = UserPro.FlagDate;
                user.EndLevel = UserPro.EndLevel;
                user.LastLevel = UserPro.LastLevel;
                user.Pro001 = UserPro.Pro001;
                user.ProMoney = UserPro.ProMoney;
                user.Remark = UserPro.Remark;
                user.UserID = UserPro.UserID; 
                dbc.UserPro.Add(user); 
                dbc.SaveChanges();
                return user.ID; 
             
            }
        }
      

        Member_LevelDTO IMemberLevelService.Member_Leve()
        {
            throw new NotImplementedException();
        }
        public List<UserProDTO> GetUerProList(int pageIndex, int pageSize)
        {
            int startRow = (pageIndex - 1) * pageSize;
            using (MyDbContext dbc = new MyDbContext())
            {
                List<UserProEntity> list = new List<UserProEntity>();
                CommonService<UserProEntity> cs = new CommonService<UserProEntity>(dbc);
                return cs.GetAll().ToList().Skip(startRow).Take(pageSize).Select(r=> new UserProDTO {
                    UserID = r.UserID,
                    LastLevel = r.LastLevel,
                    EndLevel = r.EndLevel,
                    Flag = r.Flag,
                    FlagDate = r.FlagDate,
                    AddDate = r.AddDate,
                    CreateTime = r.CreateTime,
                    ID=r.ID,
                    Pro001 = r.Pro001,
                    Remark=r.Remark,
                    ProMoney=r.ProMoney
                }).ToList();
            }
        }
        public List<UserProDTO> GetUerProCount()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                List<UserProEntity> list = new List<UserProEntity>();
                CommonService<UserProEntity> cs = new CommonService<UserProEntity>(dbc);
                return cs.GetAll().ToList().Select(r => new UserProDTO
                {
                    UserID = r.UserID,
                    LastLevel = r.LastLevel,
                    EndLevel = r.EndLevel,
                    Flag = r.Flag,
                    FlagDate = r.FlagDate,
                    AddDate = r.AddDate,
                    CreateTime = r.CreateTime,
                    ID = r.ID,
                    Pro001 = r.Pro001,
                    Remark = r.Remark,
                    ProMoney = r.ProMoney
                }).ToList();
            }
        }
    }
}
