using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class TakeCashStateConfig:EntityTypeConfiguration<TakeCashStateEntity>
    {
        public TakeCashStateConfig()
        {
            ToTable("T_TakeCashStates");
            Property(t => t.Name).HasMaxLength(50).IsRequired();
        }
    }
}
