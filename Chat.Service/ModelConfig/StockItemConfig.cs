using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    public class StockItemConfig:EntityTypeConfiguration<StockItemEntity>
    {
        public StockItemConfig()
        {
            ToTable("T_StockItems");
            Property(s => s.KeyName).HasMaxLength(10).IsRequired().IsUnicode();
            Property(s => s.Name).HasMaxLength(50).IsRequired();
            Property(s => s.Description).HasMaxLength(200);
        }
    }
}
