using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.Entities
{    
    public class NewsEntity:BaseEntity
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        /// <summary>
        /// 预览内容
        /// </summary>
        public string Preview { get; set; }
        public long? NewsTypeId { get; set; }
        /// <summary>
        /// 公告图片地址
        /// </summary>
        public string ImgURL { get; set; }
        /// <summary>
        /// 阅读比例
        /// </summary>
        public decimal Rate { get; set; } = 0;
        /// <summary>
        /// 点击数
        /// </summary>
        public long Click { get; set; } = 0;
        public virtual AdminEntity Admin { get; set; }
        public long AdminId { get; set; }
    }
}
