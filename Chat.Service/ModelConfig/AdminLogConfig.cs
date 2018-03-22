using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SDMS.Service.ModelConfig
{
    class AdminLogConfig:EntityTypeConfiguration<AdminLogEntity>
    {
        public AdminLogConfig()
        {
            ToTable("T_AdminLogs");
            HasRequired(a => a.AdminUser).WithMany().HasForeignKey(a => a.AdminUserId).WillCascadeOnDelete(false);
            Property(a => a.IpAddress).HasMaxLength(20).IsUnicode();
            Property(a => a.Message).HasMaxLength(256);
        }
    }
}
