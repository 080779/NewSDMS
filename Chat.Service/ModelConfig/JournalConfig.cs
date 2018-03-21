using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class JournalConfig : EntityTypeConfiguration<JournalEntity>
    {
        public JournalConfig()
        {
            ToTable("T_Journal");
            Property(u => u.Remark).HasMaxLength(50);
            HasRequired(j => j.Holder).WithMany().HasForeignKey(j => j.HolderId).WillCascadeOnDelete(false);
            HasRequired(j => j.JournalType).WithMany().HasForeignKey(j => j.JournalTypeId).WillCascadeOnDelete(false);
        }
    }
}