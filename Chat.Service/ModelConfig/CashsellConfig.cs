using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class CashsellConfig : EntityTypeConfiguration<CashsellEntity>
    {
        public CashsellConfig()
        {
            ToTable("T_Cashsell");

            Property(u => u.Title).HasMaxLength(50);
            Property(u => u.Remark).HasMaxLength(50);
        }
    }
}