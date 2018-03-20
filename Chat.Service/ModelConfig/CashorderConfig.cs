using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class CashorderConfig : EntityTypeConfiguration<CashorderEntity>
    {
        public CashorderConfig()
        {
            ToTable("T_Cashorder");

            Property(u => u.OrderCode).HasMaxLength(50);
            Property(u => u.BRemark).HasMaxLength(50);
            Property(u => u.SRemark).HasMaxLength(50);
        }
    }
}