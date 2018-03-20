using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class ChangeConfig : EntityTypeConfiguration<ChangeEntity>
    {
        public ChangeConfig()
        {
            ToTable("T_Change");

            Property(u => u.Change003).HasMaxLength(50);
            Property(u => u.Change004).HasMaxLength(50);
            HasRequired(t => t.UserInfo).WithMany().HasForeignKey(t => t.UserID).WillCascadeOnDelete(false);
            HasRequired(t => t.ToUserInfo).WithMany().HasForeignKey(t => t.ToUserID).WillCascadeOnDelete(false);
            HasRequired(t => t.ChangeTypeInfo).WithMany().HasForeignKey(t => t.ChangeType).WillCascadeOnDelete(false);
        }
    }
}