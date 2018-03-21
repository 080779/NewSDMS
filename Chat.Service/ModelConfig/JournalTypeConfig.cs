using SDMS.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class JournalTypeConfig: EntityTypeConfiguration<JournalTypeEntity>
    {
        public JournalTypeConfig()
        {
            ToTable("T_JouranlType");
            Property(j => j.Name).HasMaxLength(20).IsRequired();
            Property(j => j.Description).HasMaxLength(50).IsRequired();
        }
    }
}
