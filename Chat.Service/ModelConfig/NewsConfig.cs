using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class NewsConfig : EntityTypeConfiguration<NewsEntity>
    {
        public NewsConfig()
        {
            ToTable("T_News");
        }
    }
}