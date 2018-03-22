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
            ToTable("T_Holer");
            //HasRequired(h => h.StockItem).WithMany().HasForeignKey(h => h.StockItemId).WillCascadeOnDelete(false);
            Property(h => h.Name).HasMaxLength(50);
            Property(h => h.BankName).HasMaxLength(50);
            Property(h => h.BankAccount).HasMaxLength(50);
            Property(h => h.Contact).HasMaxLength(50);
            Property(h => h.IdNumber).HasMaxLength(50);
            Property(h => h.Mobile).HasMaxLength(50);
            Property(h => h.Password).HasMaxLength(50);
            Property(h => h.TradePassword).HasMaxLength(50);
        }
    }
}
