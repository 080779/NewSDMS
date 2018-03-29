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
    public class MessageService : IMessageService
    {
        public long AddNew(long holderId,long newsId, string contents)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                MessageEntity entity = new MessageEntity();
                entity.Contents = contents;
                entity.HolderId = holderId;
                entity.NewsId = newsId;
                dbc.Messages.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }
        public MessageSearchResult GetPageList(long? holderId, string name, string mobile, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<MessageEntity> cs = new CommonService<MessageEntity>(dbc);
                MessageSearchResult result = new MessageSearchResult();
                var entity = cs.GetAll();
                if(entity==null)
                {
                    return result;
                }
                if (holderId != null)
                {
                    entity = entity.Where(m => m.HolderId == holderId);
                }
                if (!string.IsNullOrEmpty(mobile))
                {
                    entity = entity.Where(m => m.Holder.Mobile.Contains(mobile));
                }
                if (!string.IsNullOrEmpty(name))
                {
                    entity = entity.Where(m => m.Holder.Name.Contains(name));
                }
                if (startTime != null)
                {
                    entity = entity.Where(m => m.CreateTime >= startTime);
                }
                if (endTime != null)
                {
                    entity = entity.Where(m => m.CreateTime <= endTime);
                }
                result.TotalCount = entity.LongCount();
                result.Messages = entity.OrderByDescending(p => p.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(p => ToDTO(p)).ToArray();               

                return result;
            }
        }

        public MessageDTO ToDTO(MessageEntity entity)
        {
            MessageDTO dto = new MessageDTO();
            dto.Contents = entity.Contents;
            dto.CreateTime = entity.CreateTime;
            dto.Flag = entity.Flag;
            dto.HolderId = entity.HolderId;
            dto.Id = entity.Id;
            dto.Mobile = entity.Holder.Mobile;
            dto.Name = entity.Holder.Name;
            dto.NewsId = entity.NewsId;
            dto.HolderName = entity.Holder.Name;
            dto.NewsTitle = entity.News.Title;
            return dto;
        }
    }
}
