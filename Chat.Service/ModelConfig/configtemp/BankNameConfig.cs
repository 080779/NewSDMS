using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class BankNameConfig //: EntityTypeConfiguration<BankNameEntity>
    {
        public BankNameConfig()
        {
            //ToTable("T_BankName");

            //Property(u => u.BankName).HasMaxLength(50);
            //Property(u => u.BankNameEn).HasMaxLength(50);
        }
    }
}