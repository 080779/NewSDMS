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
        public long AddNew(long holderId, long newsId)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                ReadNumberEntity entity = new ReadNumberEntity();
                entity.HolderId = holderId;
                entity.NewsId = newsId;
                dbc.ReadNumbers.Add(entity);
                dbc.SaveChanges();
                return entity.Id;
            }
        }
    }
}
