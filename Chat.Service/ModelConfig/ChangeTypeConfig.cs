using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;

namespace SDMS.Service.ModelConfig
{
    public class ChangeTypeConfig : EntityTypeConfiguration<ChangeTypeEntity>
    {
        public ChangeTypeConfig()
        {
            ToTable("T_ChangeType");

            Property(u => u.TypeName).HasMaxLength(50);
            Property(u => u.TypeNameEn).HasMaxLength(50);
        }
    }
}
