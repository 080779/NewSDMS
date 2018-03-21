using SDMS.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.IService.Interface
{
    public interface INewsService : IServiceSupport
    {
        //增加公告
        long Add(string Title, int dropNewType, string Context, DateTime Time);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        NewsPageResult GetPageList(int PageIndex, int PageSize);
        ///获取Id
        NewsDTO GetModel(long Id);
        //更新
        bool Update(NewsDTO hh);
        //前台列表
        NewsPageResult GetNewsList(int NewType,string Title, DateTime? Strat, DateTime? End, int PageIndex, int PageSize);
    }
    public class NewsPageResult
    {
        public long TotalCount { get; set; }
        public NewsDTO[] News { get; set; }
    }
}
