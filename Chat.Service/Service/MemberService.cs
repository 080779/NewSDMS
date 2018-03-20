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
    public class MemberService  : IMemberService
    {
        public LevelDTO[] GetAll()
        {
            throw new NotImplementedException();
        }
      
        public MemberSearchResult GetPageList(int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                var User = cs.GetAll();
                result.TotalCount = User.LongCount();
                result.MemberList = User.OrderByDescending(a => a.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(a => new MemberListDTO { UserCode = a.UserCode }).ToArray();
                return result;
            }
        }
        /// <summary>
        /// 后台查询i=0就是查询未开通会员
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="usercode"></param>
        /// <param name="Level"></param>
        /// <param name="Strat"></param>
        /// <param name="End"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="i">i=0就是查询未开通会员</param>
        /// <returns></returns>
        public MemberSearchResult GetMemberList(string Id, string usercode, string Level, DateTime? Strat, DateTime? End, int PageIndex, int PageSize, int i)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                //MemberDTO[] result = new MemberDTO();
               
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                var User = cs.GetAll();
                if (i==0)
                {
                    User = User.Where(a => a.IsOpend < 2);
                }
                else
                {
                    User = User.Where(a => a.IsOpend == 2);
                }

                MemberSearchResult MemberSearch = new MemberSearchResult();
                long level = Convert.ToInt64(Level);
                if (Id != "0")
                {
                    if (usercode != "")
                    { 
                        if (Id == "1")
                        {
                            User = User.Where(p => p.UserCode.Contains(usercode));
                        }
                        else if (Id == "2")
                        {
                            User = User.Where(p => p.RecommendCode.Contains(usercode));
                        }
                    }
                }
                if (Level != "0" && Level != "")
                {
                    User = User.Where(p => p.LevelID == level);
                }
                if (Strat != null)
                {
                    User = User.Where(p => p.CreateTime >= Strat);
                }
                if (End != null)
                {
                    User = User.Where(p => p.CreateTime <= End);
                }
                MemberSearch.TotalCount = User.LongCount();
                MemberSearch.MemberList = User.OrderByDescending(p => p.ID).ToList().Skip((PageIndex-1)* PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return MemberSearch;
            }
        }
        public MemberListDTO ToDTO(UserEntity User)
        {
            LevelService Level = new LevelService();
            MemberListDTO MemberList = new MemberListDTO();
            MemberList.ID= User.ID;
            MemberList.Emoney = User.Emoney;
            MemberList.UserCode = User.UserCode;
            MemberList.LevelID = User.LevelID;
            MemberList.RecommendID = User.RecommendID;
            MemberList.RecommendCode = User.RecommendCode;
            MemberList.ParentID = User.ParentID;
            MemberList.IsOpend = User.IsOpend;
            MemberList.TrueName = User.TrueName;
            MemberList.PhoneNum = User.PhoneNum;
            MemberList.CreateTime = User .CreateTime;
            MemberList.IsLock= User.IsLock;
            MemberList.OpenTime = User.OpenTime;
            MemberList.LevelName = ""; 
            if (Level.GetLevelName(MemberList.LevelID)!=null)
            {
                MemberList.LevelName = Level.GetLevelName(MemberList.LevelID).LevelName;
            }

            MemberList.BankAccount = User.BankAccount;
            MemberList.BankAccountUser = User.BankAccountUser;
            MemberList.BankName = User.BankName;
            MemberList.BankBranch = User.BankBranch;
            MemberList.BankInProvince = User.BankInProvince;
            MemberList.Location = User.Location;
            MemberList.RegMoney = User.RegMoney;
            MemberList.ParentCode = User.ParentCode;
            MemberList.IdenCode = User.IdenCode;
            MemberList.Password= User.Password;
            MemberList.ThreePassword = User.ThreePassword;
            MemberList.SecondPassword = User.SecondPassword;
            return MemberList;
        } 
        /// <summary>
        /// 查询这个ID的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>MemberListDTO
        public MemberSearchResult ToUser(int id)
        { 
            using (MyDbContext dbc = new MyDbContext())
            { 
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                var User = cs.GetAll(); 
                User = User.Where(a => a.ID == id);
                MemberSearchResult Result = new MemberSearchResult();
                Result.MemberList = User.OrderByDescending(p => p.ID).ToList().Select(a => ToDTO(a)).ToArray();
                return Result;
            }

        }

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
        public MemberSearchResult GetMemberList(string Id,int GetLoginID, string usercode, string Level, DateTime? Strat, DateTime? End, int PageIndex, int PageSize, int i)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                //MemberDTO[] result = new MemberDTO();

                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                var User = cs.GetAll();
                if (i == 0||i==3)
                {
                    if (i == 0)
                    {
                        User = User.Where(a => a.IsOpend < 2);
                    }
                    else
                    {
                        User = User.Where(a => a.IsOpend <= 2);
                    }
                    if (Strat != null)
                    {
                        User = User.Where(p => p.CreateTime >= Strat);
                    }
                    if (End != null)
                    {
                        User = User.Where(p => p.CreateTime <= End);
                    }

                }
                else
                {
                    User = User.Where(a => a.IsOpend == 2);
                    if (Strat != null)
                    {
                        User = User.Where(p => p.OpenTime >= Strat);
                    }
                    if (End != null)
                    {
                        User = User.Where(p => p.OpenTime <= End);
                    }
                }

                MemberSearchResult MemberSearch = new MemberSearchResult();
                long level = Convert.ToInt64(Level);
                if (Id != "0")
                {
                    if (usercode != "")
                    {
                        if (Id == "1")
                        {
                            User = User.Where(p => p.UserCode.Contains(usercode));
                        }
                        else if (Id == "2")
                        {
                            User = User.Where(p => p.RecommendCode.Contains(usercode));
                        }
                    }
                }
                if (GetLoginID>0)//推荐人列表
                {
                    User = User.Where(p => p.RecommendID== 9 && p.ID!= 9);
                }
                if (Level != "0")
                {
                    User = User.Where(p => p.LevelID == level);
                }
               
                MemberSearch.TotalCount = User.LongCount();
                MemberSearch.MemberList = User.OrderByDescending(p => p.ID).ToList().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return MemberSearch;
            }
        }
        /// <summary>
        /// 删除ID
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int Del(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                { 
                    //没有值就返回null
                    result.MemberList = null;
                    return 0;
                }
                //删除
                if (User.IsOpend == 2)
                {
                    result.MemberList = null;
                    return 1;
                }
                else
                {
                    User.IsDeleted = true;
                    dbc.SaveChanges();
                    return 2;

                }
                
            }
        }
        /// <summary>
        /// 激活ID
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int Pass(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.MemberList = null;
                    return 0;
                }
                //已经开通
                if (User.IsOpend == 2)
                {
                    result.MemberList = null;
                    return 1;
                }
                else
                {
                    User.IsOpend = 2;
                    User.OpenTime = DateTime.Now;
                    dbc.SaveChanges();
                    return 2;

                }

            }
        }
        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Close(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.MemberList = null;
                    return 0;
                } 
                else
                {
                    User.IsLock = 1;
                    dbc.SaveChanges();
                    return 2;

                }

            }
        }
        public int Open(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.MemberList = null;
                    return 0;
                } 
                else
                {
                    User.IsLock = 0;
                    dbc.SaveChanges(); 
                    return 2;

                }

            }
        }
        /// <summary>
        /// 修改升级
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public long Update_LeveID(int GetLoginID, int LeveID)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(GetLoginID);
                if (User == null)
                {
                    //没有值就返回null
                    result.MemberList = null;
                    return 0;
                } 
                else
                {
                    User.LevelID = LeveID;
                    dbc.SaveChanges();
                    return 2;
                }
            }
        }

        /// <summary>
        /// 修改升级,扣款，加人流水表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public long Update_LeveID(int GetLoginID, int LeveID,decimal Amount)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(GetLoginID);
                if (User == null)
                {
                    //没有值就返回null
                    result.MemberList = null;
                    return 0;
                }
                User.LevelID = LeveID;
                User.Emoney = User.Emoney - Amount;
                User.RegMoney = User.RegMoney + Amount;

                JournalEntity journal = new JournalEntity();
                journal.UserID = GetLoginID;
                journal.Remark = "会员升级";
                journal.OutAmount = Amount;
                journal.BalanceAmount = User.Emoney;
                journal.JournalDate = DateTime.Now;
                journal.JournalType = 1;
                journal.Journal01 = GetLoginID;
                dbc.Journal.Add(journal);
                dbc.SaveChanges();
                return 2;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int Update_Date(MemberListDTO MemberList)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MemberSearchResult result = new MemberSearchResult();
                CommonService<UserEntity> cs = new CommonService<UserEntity>(dbc);
                var User = cs.GetById(MemberList.ID);
                if (User==null)
                {
                    return 0;
                }
                User.TrueName = MemberList.TrueName;
                User.IdenCode = MemberList.IdenCode;
                User.PhoneNum = MemberList.PhoneNum;

                if (User.Password!= MemberList.Password)
                {
                    User.Password = MemberList.Password;
                }
                if (User.SecondPassword != MemberList.SecondPassword)
                {
                    User.SecondPassword = MemberList.SecondPassword;
                }
                if (User.ThreePassword != MemberList.ThreePassword)
                {
                    User.ThreePassword = MemberList.ThreePassword;
                }

                dbc.SaveChanges(); 
                    return 2; 
                } 
            } 
    }

    }
 
