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
    public class AgentServeice : IAgentServeice
    {
        public AgentSearchResult GetPageList(int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            { 
                AgentSearchResult result = new AgentSearchResult();
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                var User = cs.GetAll();
                result.TotalCount = User.LongCount();
                result.AgentList = User.OrderByDescending(a => a.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(a => new AgentListDTO { UserID = a.UserID }).ToArray();
                return result;
            }
        } 
        AgentDTO[] IAgentServeice.GetAll()
        {
            throw new NotImplementedException();
        }
        public string pic_data()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                var Users = from b in dbc.User
                            group b by b.LevelID into c
                            select new
                            {
                                leveID = c.Key,
                                count = c.Count()
                            };
                var json = "{\"dates\":[";
                int i = 0;
                foreach (var item in Users)
                {

                    json += "{\"value\": \""+ item.count + "\",\"name\":"+"\"" + getDate(item.leveID) + "\"},";
                    i++;
                } 
                json = json.Substring(0,json.Length-1);
                json += "]}";
                return json;
            }  
        }
        public string getDate(int LeveID)
        {
            string Name = "";
            switch (LeveID)
            {
                 case 0:
                    Name = "普通会员";
                    break;
                case 1:
                    Name = "一星会员";
                    break;
                case 2:
                    Name = "二星会员";
                    break;
                case 3:
                    Name = "三星会员";
                    break; 
                default:
                    Name = "普通会员";
                    break;
            }

            return Name;
        }



        /// <summary>
        /// i=0就是查询未开通会员，查询开通会员
        /// </summary>
        /// <param name="Id">下拉选择值</param>
        /// <param name="usercode">输入的UserCode</param>
        /// <param name="Level">选择的等级</param>
        /// <param name="Strat">开通时间</param>
        /// <param name="End">开通时间</param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="i">i=0就是查询未开通会员</param>
        /// <returns></returns>
        public AgentSearchResult GetAgentList(string Id, string usercode, DateTime? Strat, DateTime? End, int PageIndex, int PageSize, int i)
        {
            using (MyDbContext dbc = new MyDbContext())
            { 
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                var User = cs.GetAll();
                if (i == 0)
                {
                    User = User.Where(a => a.Flag ==0);
                }
                else
                {
                    User = User.Where(a => a.Flag >= 1);
                }
                AgentSearchResult AgentSearch = new AgentSearchResult(); 
                if (Id != "0")
                {
                    if (usercode != "")
                    {
                        if (Id == "1")
                        {
                            User = User.Where(p => p.AgentCode.Contains(usercode));
                        } 
                    }
                } 
                if (Strat != null)
                {
                    User = User.Where(p => p.OpenTime >= Strat);
                }
                if (End != null)
                {
                    User = User.Where(p => p.OpenTime <= End);
                }
                AgentSearch.TotalCount = User.LongCount();
                AgentSearch.AgentList = User.OrderByDescending(p => p.ID).ToList().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return AgentSearch;
            }
        } 
        public AgentListDTO ToDTO(AgentEntity User)
        {
            AgentListDTO AgentList = new AgentListDTO();
            AgentList.AgentCode = User.AgentCode;
            AgentList.Flag = User.Flag;
            AgentList.AgentType = User.AgentType;
            AgentList.OpenTime = User.OpenTime;
            AgentList.UserID = User.UserID;
            AgentList.ID = User.ID;
            AgentList.CreateTime = User.CreateTime; 
            return AgentList;
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
                AgentSearchResult result = new AgentSearchResult();
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.AgentList = null;
                    return 0;
                }
                //删除
                if (User.Flag >= 1)
                {
                     
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
                AgentSearchResult result = new AgentSearchResult();
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.AgentList = null;
                    return 0;
                }
                //已经开通
                if (User.Flag == 1)
                { 
                    return 1;
                }
                else
                {
                    User.OpenTime = DateTime.Now;
                    User.Flag = 1;
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
                AgentSearchResult result = new AgentSearchResult();
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.AgentList = null;
                    return 0;
                }
                else
                {
                    User.Flag = 2;
                    dbc.SaveChanges();
                    return 2;

                }

            }
        }
        public int Open(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                AgentSearchResult result = new AgentSearchResult();
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetById(id);
                if (User == null)
                {
                    //没有值就返回null
                    result.AgentList = null;
                    return 0;
                }
                else
                {
                    User.Flag = 1;
                    dbc.SaveChanges();
                    return 2;

                }

            }
        }
        /// <summary>
        /// 查询Agent用户存在不存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AgentSearchResult GetAgentName(string name)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                AgentSearchResult result = new AgentSearchResult();
                CommonService<AgentEntity> cs = new CommonService<AgentEntity>(dbc);
                //先查询有没有值。
                var User = cs.GetAll().Where(p=>p.AgentCode== name);
                if (User == null)
                {
                    //没有值就返回null
                    result.AgentList = null;
                    return result;
                }
                else
                {
                    result.AgentList = User.OrderByDescending(p => p.ID).ToList().Where(p=>p.AgentCode== name).Select(p=> ToAgent(p)).ToArray(); 
                    return result;

                }

            }
        }
        public AgentListDTO ToAgent (AgentEntity Agent)
        {
            AgentListDTO AgentList = new AgentListDTO();
            AgentList.AgentCode = Agent.AgentCode;
            AgentList.AgentType= Agent.AgentType;
            AgentList.CreateTime= Agent.CreateTime;
            AgentList.Flag= Agent.Flag;
            AgentList.UserID= Agent.UserID;


            return AgentList;
        }
        /// <summary>
        /// 添加申请报单中心记录数据
        /// </summary>
        /// <param name="UserPro"></param>
        /// <returns></returns>
        public long Add(AgentListDTO AgentList)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                AgentEntity user = new AgentEntity();
                user.AgentCode = AgentList.AgentCode;
                user.AgentType = AgentList.AgentType;
                user.CreateTime = AgentList.CreateTime;
                user.Flag = AgentList.Flag;
                user.UserID = AgentList.UserID;
                user.AppliTime = DateTime.Now;
                dbc.Agent.Add(user);
                dbc.SaveChanges();
                return user.ID;

            }
        }


    }
}
