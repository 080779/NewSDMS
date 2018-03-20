using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class GoodsConfig : EntityTypeConfiguration<GoodsEntity>
    {
        public GoodsConfig()
        {
            ToTable("T_Goods");

            Property(u => u.GoodsCode).HasMaxLength(50);
            Property(u => u.GoodsName).HasMaxLength(50);
            Property(u => u.Standard).HasMaxLength(50);
            Property(u => u.Pic1).HasMaxLength(50);
            Property(u => u.Pic2).HasMaxLength(50);
            Property(u => u.Pic3).HasMaxLength(50);
            Property(u => u.Pic4).HasMaxLength(50);
            Property(u => u.Pic5).HasMaxLength(50);
            Property(u => u.Summary).HasMaxLength(50);
            Property(u => u.Remarks).HasMaxLength(50);
            Property(u => u.Goods003).HasMaxLength(50);
            Property(u => u.Goods004).HasMaxLength(50);
            Property(u => u.GoodsName_en).HasMaxLength(50);
            Property(u => u.Remarks_en).HasMaxLength(50);
        }
    }
}