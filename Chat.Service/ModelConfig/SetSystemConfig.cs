using SDMS.Service.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMS.Service.ModelConfig
{
    class SetSystemConfig : EntityTypeConfiguration<SetSystemEntity>
    {
        public SetSystemConfig()
        {
            ToTable("T_SetSystem");
        }
    }
}