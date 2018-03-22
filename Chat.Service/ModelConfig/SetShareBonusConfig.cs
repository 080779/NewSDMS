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
        }
    }
}
