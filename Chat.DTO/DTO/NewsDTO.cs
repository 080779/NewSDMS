using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.DTO.DTO
{
    public class NewsDTO : BaseDTO
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
        public decimal Rate { get; set; }
        /// <summary>
        /// 点击数
        /// </summary>
        public long Click { get; set; } = 0;
        public long AdminId { get; set; }
        public string Publisher { get; set; }
    }
}
