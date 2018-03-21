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
        }
    }
}
