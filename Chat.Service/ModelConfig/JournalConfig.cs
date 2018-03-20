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
            Property(u => u.RemarkEn).HasMaxLength(50);
            Property(u => u.Journal03).HasMaxLength(50);
            Property(u => u.Journal04).HasMaxLength(50);
            //HasRequired(b => b.Users).WithMany().HasForeignKey(b => b.UserID).WillCascadeOnDelete(false);
            HasRequired(b => b.Currencys).WithMany().HasForeignKey(b => b.JournalType).WillCascadeOnDelete(false);
        }
    }
}