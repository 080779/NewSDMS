using SDMS.Common;
using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDMS.IService.Interface.INewsService;

namespace SDMS.Service.Service
{
    public class NewsService : INewsService
    {
        public long AddNew(long adminId, string title, string imgUrl, string contents)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                NewsEntity entity = new NewsEntity();
                entity.AdminId = adminId;
                entity.Title = title;
                entity.Contents = contents;
                entity.Preview = CommonHelper.NoHTML(contents);
                entity.ImgURL = imgUrl;
                entity.Rate = 0;
                entity.Click = 0;
                dbc.News.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<NewsEntity> cs = new CommonService<NewsEntity>(dbc);
                var news = cs.GetAll().SingleOrDefault(n => n.Id == id);
                if(news==null)
                {
                    return false;
                }
                news.IsDeleted = true;
                dbc.SaveChanges();
                return true;
            }
        }

        public NewsDTO GetById(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<NewsEntity> cs = new CommonService<NewsEntity>(dbc);
                var news = cs.GetAll().SingleOrDefault(n => n.Id == id);
                if(news==null)
                {
                    return null;
                }
                return ToDTO(news);
            }
        }
        public NewsSearchResult GetPageList(string title, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<NewsEntity> cs = new CommonService<NewsEntity>(dbc);
                NewsSearchResult result = new NewsSearchResult();
                var news = cs.GetAll();
                if(news==null)
                {
                    return result;
                }
                if(!string.IsNullOrEmpty(title))
                {
                    news = news.Where(n => n.Title.Contains(title));
                }
                if (startTime != null)
                {
                    news = news.Where(p => p.CreateTime >= startTime);
                }
                if (endTime != null)
                {
                    news = news.Where(p => p.CreateTime <= endTime);
                }
                result.TotalCount = news.LongCount();
                result.News=news.OrderByDescending(p => p.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(p => ToDTO(p)).ToArray();
                return result;
            }
        }

        public bool Update(long id, string title, string content, string imgUrl)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<NewsEntity> cs = new CommonService<NewsEntity>(dbc);
                var news = cs.GetAll().SingleOrDefault(n => n.Id == id);
                if (news == null)
                {
                    return false;
                }
                news.Title = title;
                news.Contents = content;
                news.ImgURL = imgUrl;
                dbc.SaveChanges();
                return true;
            }
        }

        public NewsDTO ToDTO(NewsEntity entity)
        {
            NewsDTO dto = new NewsDTO();
            dto.AdminId = entity.AdminId;
            dto.Click = entity.Click;
            dto.Content = entity.Contents;
            dto.CreateTime = entity.CreateTime;
            dto.Id = entity.Id;
            dto.ImgURL = entity.ImgURL;
            dto.NewsTypeId = entity.NewsTypeId;
            dto.Publisher = entity.Admin.Name;
            dto.Rate = entity.Rate;
            dto.Title = entity.Title;
            dto.Preview = entity.Preview;
            return dto;
        }
    }
}
  

