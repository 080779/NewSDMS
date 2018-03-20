using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class AddressConfig : EntityTypeConfiguration<AddressEntity>
    {
        public AddressConfig()
        {
            ToTable("T_Address");
            Property(u => u.AreaInProvince).HasMaxLength(50);
            Property(u => u.AreaInCity).HasMaxLength(50);
            Property(u => u.Address).HasMaxLength(256);
            Property(u => u.PostCode).HasMaxLength(50);
            Property(u => u.MemberName).HasMaxLength(50);
            Property(u => u.PhoneNum).HasMaxLength(50);
            Property(u => u.Phone).HasMaxLength(50);
            Property(u => u.Mail).HasMaxLength(50);
            Property(u => u.Remark).HasMaxLength(50);
            Property(u => u.Address01).HasMaxLength(256);
            Property(u => u.Address02).HasMaxLength(256);
            Property(u => u.Address03).HasMaxLength(256);
            Property(u => u.Address04).HasMaxLength(256);
        }
    }
}
