using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class BonusTypeConfig //: EntityTypeConfiguration<BonusTypeEntity>
    {
        public BonusTypeConfig()
        {
            //ToTable("T_BonusType");
            //Property(u => u.TypeName).HasMaxLength(50);
            //Property(u => u.TypeNameEn).HasMaxLength(50);
        }
    }
}