using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class PowerConfig : EntityTypeConfiguration<PowerEntity>
    {
        public PowerConfig()
        {
            ToTable("T_Power");
            Property(p => p.MenuName).HasMaxLength(50);
            Property(p => p.URL).HasMaxLength(50);
        }
    }
}