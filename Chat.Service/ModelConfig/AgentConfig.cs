using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class AgentConfig : EntityTypeConfiguration<AgentEntity>
    {
        public AgentConfig()
        {
            ToTable("T_Agent");

            Property(u => u.AgentCode).HasMaxLength(50);
            Property(u => u.PicLink).HasMaxLength(50);
            Property(u => u.AgentInProvince).HasMaxLength(50);
            Property(u => u.AgentInCity).HasMaxLength(50);
            Property(u => u.AgentAddress).HasMaxLength(256);
            Property(u => u.Agent003).HasMaxLength(50);
            Property(u => u.Agent004).HasMaxLength(50);
            Property(u => u.Agent005).HasMaxLength(50);
            Property(u => u.Agent006).HasMaxLength(50);
        }
    }
}