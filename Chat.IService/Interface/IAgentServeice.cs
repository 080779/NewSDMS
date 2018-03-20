using System;
using SDMS.DTO.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface IAgentServeice: IServiceSupport
    {
        string pic_data();
        AgentDTO[] GetAll();
        AgentSearchResult GetPageList(int pageIndex, int pageSize);
        AgentSearchResult GetAgentList(string Id, string usercode, DateTime? Strat, DateTime? End, int PageIndex, int PageSize, int i);
        int Del(long id);
        int Open(long id);
        int Close(long id);
        int Pass(long id);
        long Add(AgentListDTO AgentList);
        /// <summary>
        /// 用AgentCode来查询信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        AgentSearchResult GetAgentName(string name);
    }
    public class AgentSearchResult
    {
        public AgentListDTO[] AgentList { get; set; }
        public long TotalCount { get; set; }
    }
}
