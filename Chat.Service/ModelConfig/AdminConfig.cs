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
        /// ����Ա�û��������ݿ������
        /// </summary>
        public AdminConfig()
        {
            ToTable("T_Admin");
            //��Զ��ϵ���ã����ûὨһ�Ź�ϵ�����Զ��ϵ
            HasMany(r => r.Roles).WithMany(u => u.AdminUsers).Map(m => m.ToTable("T_AdminUserRole").MapLeftKey("AdminUserID").MapRightKey("RoleID"));
            //string �������ã������������ɵı��ֶ��Ǳ���ģ��ַ�������50
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
