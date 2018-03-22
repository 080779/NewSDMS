using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SDMS.Service.ModelConfig
{
    class ReadNumberConfig:EntityTypeConfiguration<ReadNumberEntity>
    {
        public ReadNumberConfig()
        {
            ToTable("T_ReadNumbers");
            HasRequired(r => r.Holder).WithMany().HasForeignKey(r => r.HolderId).WillCascadeOnDelete(false);
            HasRequired(r => r.News).WithMany().HasForeignKey(r => r.NewsId).WillCascadeOnDelete(false);
        }
    }
}
