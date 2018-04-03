using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SDMS.Service.ModelConfig
{
    class SettingsConfig:EntityTypeConfiguration<SettingsEntity>
    {
        public SettingsConfig()
        {
            ToTable("T_Settings");
            Property(s => s.Description).HasMaxLength(100);
            Property(s => s.Name).HasMaxLength(50).IsRequired();
            Property(s => s.Value).HasMaxLength(300).IsRequired().IsUnicode();
        }
    }
}
