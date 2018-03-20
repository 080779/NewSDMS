using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class BonusConfig : EntityTypeConfiguration<BonusEntity>
    {
        public BonusConfig()
        {
            ToTable("T_Bonus");

            Property(u => u.Source).HasMaxLength(50);
            Property(u => u.SourceEn).HasMaxLength(50);
            Property(u => u.Bonus003).HasMaxLength(50);
            Property(u => u.Bonus004).HasMaxLength(50);
            HasRequired(b => b.Users).WithMany().HasForeignKey(b => b.UserID).WillCascadeOnDelete(false);
            HasRequired(b => b.BonusTypes).WithMany().HasForeignKey(b => b.TypeID).WillCascadeOnDelete(false);
        }
    }
}