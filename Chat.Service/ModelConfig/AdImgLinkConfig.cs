using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SDMS.Service.ModelConfig
{
    class AdImgLinkConfig:EntityTypeConfiguration<AdImgLinkEntity>
    {
        public AdImgLinkConfig()
        {
            ToTable("T_AdImgLinks");
            Property(a=>a.Name).HasMaxLength(50).IsRequired();
            Property(a=>a.Url).HasMaxLength(200);
        }
    }
}
