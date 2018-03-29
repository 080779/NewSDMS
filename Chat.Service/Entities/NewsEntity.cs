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
        /// Ԥ������
        /// </summary>
        public string Preview { get; set; }
        public long? NewsTypeId { get; set; }
        /// <summary>
        /// ����ͼƬ��ַ
        /// </summary>
        public string ImgURL { get; set; }
        /// <summary>
        /// �Ķ�����
        /// </summary>
        public decimal Rate { get; set; } = 0;
        /// <summary>
        /// �����
        /// </summary>
        public long Click { get; set; } = 0;
        public virtual AdminEntity Admin { get; set; }
        public long AdminId { get; set; }
    }
}
