using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SDMS.Service.ModelConfig
{
    class TakeCashConfig:EntityTypeConfiguration<TakeCashEntity>
    {
        public TakeCashConfig()
        {
            ToTable("T_TakeCashs");
            HasRequired(t => t.Holder).WithMany().HasForeignKey(t => t.HolderId).WillCascadeOnDelete(false);
            HasRequired(t => t.State).WithMany().HasForeignKey(t => t.StateId).WillCascadeOnDelete(false);
            Property(t => t.ImgUrl).HasMaxLength(50);
            Property(t => t.Message).HasMaxLength(50);
        }
    }
}
