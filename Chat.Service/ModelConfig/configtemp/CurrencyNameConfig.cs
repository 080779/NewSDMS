using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;

namespace SDMS.Service.ModelConfig
{
    public class CurrencyNameConfig //: EntityTypeConfiguration<CurrencyNameEntity>
    {
        public CurrencyNameConfig()
        {
            //ToTable("T_CurrencyName");

            //Property(u => u.CurrencyName).HasMaxLength(50);
            //Property(u => u.CurrencyNameEn).HasMaxLength(50);
        }
    }
}
