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
    public class ReadNumberService : IReadNumberService
    {
        public void AddNew(long holderId, long newsId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                ReadNumberEntity entity = new ReadNumberEntity();
                CommonService<ReadNumberEntity> cs = new CommonService<ReadNumberEntity>(dbc);
                CommonService<NewsEntity> ncs = new CommonService<NewsEntity>(dbc);
                CommonService<HolderEntity> hcs = new CommonService<HolderEntity>(dbc);
                var rues = cs.GetAll().Where(r => r.NewsId == newsId);
                if(rues==null)
                {
                    entity.HolderId = holderId;
                    entity.NewsId = newsId;
                    dbc.ReadNumbers.Add(entity);
                    var news = ncs.GetAll().SingleOrDefault(n => n.Id == newsId);
                    if (news == null)
                    {
                        return;
                    }
                    news.Click++;
                    news.Rate = news.Click / hcs.GetAll().LongCount();
                }
                else
                {
                    var rue = rues.SingleOrDefault(r => r.HolderId == holderId);
                    if (rue != null)
                    {
                        return;
                    }
                    entity.HolderId = holderId;
                    entity.NewsId = newsId;
                    dbc.ReadNumbers.Add(entity);
                    var news = ncs.GetAll().SingleOrDefault(n => n.Id == newsId);
                    if (news == null)
                    {
                        return;
                    }
                    news.Click++;
                    news.Rate = news.Click / hcs.GetAll().LongCount();
                }                
                dbc.SaveChanges();
            }
        }

        public ReadNumberDTO[] GetByNewsId(long id)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<ReadNumberEntity> cs = new CommonService<ReadNumberEntity>(dbc);
                var entity = cs.GetAll().Where(r => r.NewsId == id);
                if(entity==null)
                {
                    return null;
                }
                return entity.ToList().Select(r => ToDTO(r)).ToArray();
            }
        }
        public ReadNumberDTO ToDTO(ReadNumberEntity entity)
        {
            ReadNumberDTO dto = new ReadNumberDTO();
            dto.CreateTime = entity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            dto.HolderName = entity.Holder.Name;
            dto.NewsTitle = entity.News.Title;
            return dto;
        }
    }
}
