using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SDMS.Service.ModelConfig
{
    class SetShareBonusConfig:EntityTypeConfiguration<SetShareBonusEntity>
    {
        public SetShareBonusConfig()
        {
            ToTable("T_SetShareBonus");
            Property(s => s.Name).IsRequired().HasMaxLength(50);
            Property(s => s.Rate).HasPrecision(18, 4);
            Property(s => s.OldRate).HasPrecision(18, 4);
        }
    }
}
