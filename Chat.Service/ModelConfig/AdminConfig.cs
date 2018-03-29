using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class AdminConfig : EntityTypeConfiguration<AdminEntity>
    {
        /// <summary>
        /// 管理员用户关联数据库表配置
        /// </summary>
        public AdminConfig()
        {
            ToTable("T_Admin");
            //多对多关系配置，配置会建一张关系表保存多对多关系
            HasMany(r => r.Roles).WithMany(u => u.AdminUsers).Map(m => m.ToTable("T_AdminUserRole").MapLeftKey("AdminUserID").MapRightKey("RoleID"));
            //string 类型配置，根据配置生成的表字段是必须的，字符长度是50
            Property(u => u.Name).IsRequired().HasMaxLength(50);
            Property(u => u.Description).IsRequired().HasMaxLength(100);
            Property(u => u.TrueName).HasMaxLength(50);
            Property(u => u.PasswordHash).HasMaxLength(100).IsRequired().IsUnicode(false);
            Property(u => u.PasswordSalt).HasMaxLength(10).IsRequired().IsUnicode(false);
            //Property(u => u.ThirdPassword).HasMaxLength(100).IsRequired().IsUnicode(false);
            //Property(u => u.FourPassword).HasMaxLength(100).IsUnicode(false);
        }
    }
}
