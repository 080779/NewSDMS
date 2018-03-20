using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class RemitConfig //: EntityTypeConfiguration<RemitEntity>
    {
        public RemitConfig()
        {
            //ToTable("T_Remit");

            //HasRequired(e => e.Users).WithMany().HasForeignKey(e => e.UserID).WillCascadeOnDelete(false);
        }
    }
}