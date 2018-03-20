using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class LinkConfig : EntityTypeConfiguration<LinkEntity>
    {
        public LinkConfig()
        {
            ToTable("T_Link");
        }
    }
}