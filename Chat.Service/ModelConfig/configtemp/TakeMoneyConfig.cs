using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class TakeMoneyConfig //: EntityTypeConfiguration<TakeMoneyEntity>
    {
        public TakeMoneyConfig()
        {
            //ToTable("T_TakeMoney");
            
            //HasRequired(t => t.Users).WithMany().HasForeignKey(t => t.UserID).WillCascadeOnDelete(false);
        }
    }
}