using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class CityConfig //: EntityTypeConfiguration<CityEntity>
    {
        public CityConfig()
        {
            //ToTable("T_City");

            //Property(u => u.CityID).HasMaxLength(50);
            //Property(u => u.City).HasMaxLength(50);
            //Property(u => u.CityEn).HasMaxLength(50);
            //Property(u => u.Father).HasMaxLength(50);
        }
    }
}