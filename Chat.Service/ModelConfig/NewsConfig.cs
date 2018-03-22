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
            Property(n => n.Content).HasMaxLength(50);
            Property(n => n.ImgURL).HasMaxLength(50);
            Property(n => n.Title).HasMaxLength(50);
            HasRequired(n => n.Admin).WithMany().HasForeignKey(n => n.AdminId).WillCascadeOnDelete(false);
        }
    }
}