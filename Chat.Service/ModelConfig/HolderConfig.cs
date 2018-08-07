using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class HolerConfig : EntityTypeConfiguration<HolderEntity>
    {
        public HolerConfig()
        {
            ToTable("T_Holder");
            //HasRequired(h => h.StockItem).WithMany().HasForeignKey(h => h.StockItemId).WillCascadeOnDelete(false);
            Property(h => h.Proportion).HasPrecision(18, 6);
            Property(h => h.Name).HasMaxLength(50).IsRequired();
            Property(h => h.BankName).HasMaxLength(50);
            Property(h => h.OpenId).HasMaxLength(100).IsUnicode();
            Property(h => h.Address).HasMaxLength(500);
            Property(h => h.HeadImgUrl).HasMaxLength(200).IsUnicode();
            Property(h => h.BankAccount).HasMaxLength(50);
            Property(h => h.Contact).HasMaxLength(50);
            Property(h => h.IdNumber).HasMaxLength(50).IsRequired();
            Property(h => h.Mobile).HasMaxLength(50).IsRequired();
            Property(h => h.Password).HasMaxLength(50).IsRequired();
            Property(h => h.TradePassword).HasMaxLength(50);
            Property(h => h.UrgencyContact).HasMaxLength(50);
            Property(h => h.UrgencyName).HasMaxLength(50);
        }
    }
}
