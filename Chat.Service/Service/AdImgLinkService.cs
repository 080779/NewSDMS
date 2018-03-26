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
    public class AdImgLinkService : IAdImgLinkService
    {
        public AdImgLinkDTO[] GetPageList()
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdImgLinkEntity> cs = new CommonService<AdImgLinkEntity>(dbc);
                var adImgLinks = cs.GetAll();
                if(adImgLinks==null)
                {
                    return null;
                }
                return adImgLinks.OrderByDescending(a => a.CreateTime).ToList().Select(a => new AdImgLinkDTO { Id = a.Id, Name = a.Name, CreateTime = a.CreateTime, Url = a.Url }).ToArray();
            }
        }

        public bool Update(long id,string name, string url)
        {
            using (MyDbContext dbc = new MyDbContext())
            {
                CommonService<AdImgLinkEntity> cs = new CommonService<AdImgLinkEntity>(dbc);
                var adImgLink = cs.GetAll().SingleOrDefault(a=>a.Id==id); 
                if(adImgLink==null)
                {
                    return false;
                }
                adImgLink.Name = name;
                adImgLink.Url = url;
                dbc.SaveChanges();
                return true;
            }
        }
    }
}
